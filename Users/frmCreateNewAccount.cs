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
                // Set title and button text
                btnSignIn.Text = "Save";

                if (_UpdateMode == enUpdateMode.UpdateInfo)
                {
                    // Hide some UI
                    lblTitle.Text = "Update Your Account";
                    // Disable email textbox because it is not allowed to change email in update mode
                    txtEmail.Enabled = false;
                    _HidePasswordUI();
                }
                else
                {
                    lblTitle.Text = "Change Password";
                    _DisableUIExceptPassword();
                }

                await _LoadUserInfoAsync();
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
            pbShowHideConfirmPassword.Visible = false;
            pbShowHidePassword.Visible = false;
        }

        private async Task _LoadUserInfoAsync()
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

        private bool _ValidateRequiredField(TextBox ctrl, string name)
        {
            if (string.IsNullOrWhiteSpace(ctrl.Text))
            {
                errorProvider1.SetError(ctrl, $"Please enter the {name}");
                return false;
            }
            else
            {
                errorProvider1.SetError(ctrl, string.Empty);
                return true;
            }
        }

        private bool _ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Please enter the password");
                return false;
            }
            else if (!clsUtility.ValidatePassword(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character");
                return false;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
                return true;
            }
        }

        private async Task<bool> _ValidateEmailAsync()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Please enter the email");
                return false;
            }
            else if (!clsUtility.ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address");
                return false;
            }
            else if (_Mode == enMode.AddNew && await _UsersClient.IsUserExistsByEmailAsync(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "This email is already registered");
                return false;
            }
            else if (_Mode == enMode.Update && await _UsersClient.IsUserExistsByEmailAsync(txtEmail.Text) && _User.Email != txtEmail.Text)
            {
                errorProvider1.SetError(txtEmail, "This email is already registered with another user");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
                return true;
            }
        }

        private async Task<bool> _IsValidDataAsync()
        {
            bool isValid = true;

            isValid = isValid & _ValidateRequiredField(txtFirstName, "first name");
            isValid = isValid & _ValidateRequiredField(txtLastName, "last name");
            isValid = isValid & await _ValidateEmailAsync();
            isValid = isValid & _ValidateRequiredField(txtPhone, "phone");

            // Validate password only if user is in add new mode
            if (_Mode == enMode.AddNew)
            {
                isValid = isValid & _ValidatePassword();
            }

            return isValid;
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
            {

            if (MessageBox.Show(gvMessages.askForSaveMessage("User"), "Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // save user if user in add new mode or update info mode
                if (_UpdateMode == enUpdateMode.UpdateInfo || _Mode == enMode.AddNew)
                {
                    if (await _IsValidDataAsync())
                    {
                        await _SaveUserAsync();
                        MessageBox.Show("User information saved successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please enter the required data", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // change password if user in change password mode
                else
                {
                    if (_ValidatePassword())
                    {
                        await _ChangePasswordAsync();
                        MessageBox.Show("Password changed successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please enter the required data", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void pbShowHidePassword_Click(object sender, EventArgs e)
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

        private void pbShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.UseSystemPasswordChar == true)
            {
                // Show password in plain text
                pbShowHideConfirmPassword.Image = Properties.Resources.show;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pbShowHideConfirmPassword.Image = Properties.Resources.hide;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
