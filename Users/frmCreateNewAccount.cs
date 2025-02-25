using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using ComputerStore_Business;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ApiClients.ClientDtos.UserDto;

namespace Computer_Store
{
    public partial class frmCreateNewAccount : Form
    {
        private UsersApiClient _UsersClient = new UsersApiClient(ApiUrls.UsersURL);

        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;
        private enRole _Role;

        public enum enUpdateMode { UpdateInfo = 0, ChangePassword = 1 }
        private enUpdateMode _UpdateMode;

        private UserDto _User = new UserDto();
        private int? _UserID;

        public frmCreateNewAccount(int? userID, enRole role, byte updateMode)
        {
            InitializeComponent();

            _Role = role;
            _UserID = userID;
            _UpdateMode = (enUpdateMode)updateMode;

            if (_UserID.HasValue)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

            // Subscripe some textBox to prevent user to press space button
            txtFirstName.KeyPress += TextBox_KeyPress;
            txtLastName.KeyPress += TextBox_KeyPress;
            txtEmail.KeyPress += TextBox_KeyPress;
            txtPhone.KeyPress += TextBox_KeyPress;
        }

        private async void frmCreateNewAccount_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                // Set title
                lblTitle.Text = "Sign Up";
            }
            else
            {
                // Set title and change button to save
                lblTitle.Text = "Update Your Account";
                btnSignIn.Text = "Save";

                if (_UpdateMode == enUpdateMode.UpdateInfo)
                {
                    // Hide some UI
                    _HidePasswordUI();
                }
                else
                {
                    _DisableUIExceptPassword();
                }

                await _LoadUserInfo();
            }

            if (_Role == enRole.Admin)
            {
                // Show admin account label
                lblAdmin.Visible = true;
            }
        }

        private void _DisableUIExceptPassword()
        {
            // Disable textboxes
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;

            // Disable labels
            lblFirstName.Enabled = false;
            lblLastName.Enabled = false;
            lblEmail.Enabled = false;
            lblPhone.Enabled = false;
        }

        private void _HidePasswordUI()
        {
            // Hide password UI
            lblPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            txtPassword.Visible = false;
            txtConfirmPassword.Visible = false;
        }

        private async Task _LoadUserInfo()
        {
            // Retrieve user info
            _User = await _UsersClient.FindAsync(_UserID);

            // Set user info to UI
            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;            
        }

        private void _SetUserInfo()
        {
            
            if (_UpdateMode == enUpdateMode.UpdateInfo || _Mode == enMode.AddNew)
            {
                _User.FirstName = txtFirstName.Text;
                _User.LastName = txtLastName.Text;
                _User.Email = txtEmail.Text;
                _User.Phone = txtPhone.Text;
                _User.Role = _Role;
            }
            
            if (_UpdateMode == enUpdateMode.ChangePassword || _Mode == enMode.AddNew)
            {
                _User.Password = txtPassword.Text;
            }
        }

        private async Task _SaveUserAsync()
        {
            try
            {
                _SetUserInfo();

                var savedUser = await _UsersClient.Save(_User);

                if (savedUser != null)
                {
                    MessageBox.Show(gvMessages.saveMessage("User"), gvMessages.saveTitle("User"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the form after save
                    this.Close();
                }
                else
                {
                    MessageBox.Show(gvMessages.errorSaveMessage, gvMessages.errorSaveTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _ChangePasswordAsync()
        {
            try
            {
                _SetUserInfo();

                var isChanged = await _UsersClient.ChangeUserPasswordAsync(new UserChangePasswordDto(_User.Email, _User.Password));

                if (isChanged)
                {
                    MessageBox.Show("Password changed successfully", "Change Password",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the form after save password
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password change failed", "Change Password",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Password change failed: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(gvMessages.askForSaveMessage("User"), "Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // save user if user in add new mode or update info mode
                if (_UpdateMode == enUpdateMode.UpdateInfo || _Mode == enMode.AddNew)
                {
                    await _SaveUserAsync();
                }
                // change password if user in change password mode
                else
                {
                    await _ChangePasswordAsync();
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // This will ignore the space key press
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
