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

        private UserDto _User = new UserDto();
        private int? _UserID;

        public frmCreateNewAccount(int? UserID, enRole role)
        {
            InitializeComponent();

            _Role = role;
            _UserID = UserID;

            if (_UserID == null)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
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

                await _LoadUserInfo();
            }

            if (_Role == enRole.Admin)
            {
                // Show admin account label
                lblAdmin.Visible = true;
            }
        }

        private async Task _LoadUserInfo()
        {
            _User = await _UsersClient.FindAsync(_UserID);

            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtEmail.Text = _User.Email;
            txtPhone.Text = _User.Phone;
        }

        private void _SetUserInfo()
        {
            _User.FirstName = txtFirstName.Text;
            _User.LastName = txtLastName.Text;
            _User.Email = txtEmail.Text;
            _User.Phone = txtPhone.Text;
            _User.Password = txtPassword.Text;
            _User.Role = _Role;
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

                    //this.Close(); // Close only on confirmed success
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

        private async void btnSignIn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(gvMessages.askForSaveMessage("User"), "Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _SaveUserAsync();
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
