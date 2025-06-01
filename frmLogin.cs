using ApiClients;
using ApiClients.ClientDtos;
using ComputerStore_Business;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.Api_URLs;
using static ApiClients.ClientDtos.UserDto;


namespace Computer_Store
{
    public partial class frmLogin : Form
    {
        private UsersApiClient _UsersClient = new UsersApiClient(ApiUrls.UsersURL);
        private UserSettingsApiClient _UserSettingsClient = new UserSettingsApiClient(ApiUrls.UserSettingsURL);
        private LoginRecordsApiClient _LoginRecordsClient = new LoginRecordsApiClient(ApiUrls.LoginRecordsURL);

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
           await _RetrieveSavedUserAsync();
        }

        private async Task _RetrieveSavedUserAsync()
        {

            if (clsUtility.ReadFromRegistry("SavedEmail") != string.Empty)
            {
                // Making task to retrieve username and password from registry 
                var SavedEmailTask = Task.Run(() => clsUtility.ReadFromRegistry("SavedEmail"));
                var SavedPasswordTask = Task.Run(() => clsUtility.ReadFromRegistry("SavedPassword"));

                await Task.WhenAll(SavedEmailTask, SavedPasswordTask);

                string SavedEmail = SavedEmailTask.Result.ToString();   
                string SavedPassword = SavedPasswordTask.Result.ToString();

                // Update UI on the main thread
                this.Invoke((MethodInvoker)delegate
                {
                    txtEmail.Text = SavedEmail;
                    txtPassword.Text = clsUtility.Decrypt(SavedPassword);
                });
            }
        }

        private async Task<(bool success, string errorMessage)> _CheckLoginProccessAsync(UserDto CurrentUser, LoginRecordDto LoginRecord)
        {
            bool CanPass = false;

            string errorMessage = null;

            if (CurrentUser != null)
            {
                LoginRecord.UserID = CurrentUser.ID;

                // Check if the password is correct
                if (clsUtility.ComputeHash(txtPassword.Text) == CurrentUser.Password)
                {
                    // User login successfully
                    LoginRecord.LoginStatus = true;

                    CanPass = true;
                }
                else
                {
                    // Wrong password
                    LoginRecord.LoginStatus = false;
                    LoginRecord.FailureReason = gvMessages.errorLoginWrongPassword;

                    errorMessage = gvMessages.errorLoginWrongPassword;

                    CanPass = false;
                }

                // Register login record for user
                await _LoginRecordsClient.AddNewLoginRecordAsync(LoginRecord);         
            }
            else
            {
                // Username not found
                errorMessage = gvMessages.errorLoginUsernameNotFound;

                CanPass = false;
            }

            return (CanPass, errorMessage);
        }

        private void _EnterMainScreen()
        {
            frmMain frm = new frmMain();
            frm.FormClosed += (s, args) => this.Focus(); // Ensure the login form focus when the main form is closed
            frm.Show(); 
        }

        private async Task<(bool success, string errorMessage)> _RegisterCurrentUserAsync(UserDto User)
        {
            UserSettingsDto CurrentUser = await _UserSettingsClient.FindAsync("Current User");

            if (CurrentUser == null)
            {
                return (false, gvMessages.errorLoginRegisterCurrentUser);
            }

            CurrentUser.UserID = User.ID;

            if (await _UserSettingsClient.UpdateUserSettingAsync(CurrentUser) != null)
            {
                return (true, null);
            }
            else
            {
                return (false, gvMessages.errorLoginRegisterCurrentUser);
            }
        }

        private async Task _SaveUserToRegistryAsync(UserDto user)
        {
            string SavedEmailData = user.Email;
            string SavedPasswordData = clsUtility.Encrypt(txtPassword.Text);

            // Write to registry asynchronously
            await Task.Run(() =>
            {
                clsUtility.WriteToRegistry("SavedEmail", SavedEmailData);
                clsUtility.WriteToRegistry("SavedPassword", SavedPasswordData);
            });
        }

        private async Task _SetSavedUserAsync(UserDto user)
        {
            if (ckbRememberMe.Checked)
            {
                await _SaveUserToRegistryAsync(user);
            }
        }

        private async Task _SignInAsync()
        {
            try
            {
                UserDto CurrentUser = await _UsersClient.FindAsync(txtEmail.Text);
                LoginRecordDto LoginRecord = new LoginRecordDto();

                var CheckLogin = await _CheckLoginProccessAsync(CurrentUser, LoginRecord);
                if (CheckLogin.success)
                {
                    CheckLogin = await _RegisterCurrentUserAsync(CurrentUser);
                    if (CheckLogin.success)
                    {
                        await _SetSavedUserAsync(CurrentUser);
                        _EnterMainScreen(); // This will close the login form
                    }
                    else
                    {
                        MessageBox.Show(CheckLogin.errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(CheckLogin.errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _CreateNewAccount()
        {
            frmCreateNewAccount frm = new frmCreateNewAccount(null, enRole.Customer, 0);
            frm.FormClosed += (s, args) => this.Focus(); // Ensure the login form regains focus after the create account form is closed
            frm.Show();
        }

        private void lnkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _CreateNewAccount();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }

        private void pbShowHidePassword_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                // Show password in plain text
                pbShowHidePassword.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pbShowHidePassword.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            await _SignInAsync();
        }
    }
}
