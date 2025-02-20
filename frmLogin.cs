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

        private void frmLogin_Load(object sender, EventArgs e)
        {
           _RetrieveSavedUser();
        }

        private void _RetrieveSavedUser()
        {

            if (clsUtility.ReadFromRegistry("SavedEmail") != string.Empty)
            {
                // Making task to retrieve username and password from registry 
                var SavedEmailTask = Task.Run(() => clsUtility.ReadFromRegistry("SavedEmail"));
                var SavedPasswordTask = Task.Run(() => clsUtility.ReadFromRegistry("SavedPassword"));

                Task.WaitAll(SavedEmailTask, SavedPasswordTask);

                string SavedEmail = SavedEmailTask.Result.ToString();   
                string SavedPassword = SavedPasswordTask.Result.ToString();

                txtEmail.Text = SavedEmail;
                txtPassword.Text = clsUtility.Decrypt(SavedPassword);
            }
        }

        private async Task<(bool success, string errorMessage)> _CheckLoginProccess(UserDto CurrentUser, LoginRecordDto LoginRecord)
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
            frm.ShowDialog();
        }

        private async Task<(bool success, string errorMessage)> _RegisterCurrentUser(UserDto User)
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
            string SavedEmailName = "SavedEmail";
            string SavedEmailData = user.Email;

            string SavedPasswordName = "SavedPassword";
            string SavedPasswordData = clsUtility.Encrypt(txtPassword.Text);

            // Save the user to the registry
            Task SaveUsernameTask = Task.Run(() => clsUtility.WriteToRegistry(SavedEmailName, SavedEmailData));
            Task SavePasswordTask = Task.Run(() => clsUtility.WriteToRegistry(SavedPasswordName, SavedPasswordData));

            await Task.WhenAll(SaveUsernameTask, SavePasswordTask);
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
            Task<UserDto> GetCurrentUserTask = _UsersClient.FindAsync(txtEmail.Text);
            LoginRecordDto LoginRecord = new LoginRecordDto();

            UserDto CurrentUser = await GetCurrentUserTask;

            // Check the login process
            var CheckLogin = await _CheckLoginProccess(CurrentUser, LoginRecord);
            if (CheckLogin.success)
            {
                CheckLogin = await _RegisterCurrentUser(CurrentUser);
                // Register the current user
                if (CheckLogin.success)
                {
                    await _SetSavedUserAsync(CurrentUser);
                    _EnterMainScreen();
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


        private void _CreateNewAccount()
        {
            frmCreateNewAccount frm = new frmCreateNewAccount(null, enRole.Customer);
            frm.ShowDialog();
        }

        private void lnkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _CreateNewAccount();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
