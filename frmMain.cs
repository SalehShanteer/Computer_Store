using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmMain : Form
    {

        private UserSettingsApiClient _UserSettingsClient = new UserSettingsApiClient(ApiUrls.UserSettingsURL);

        private UserDto _CurrentUser;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await _GetCurrentUserSettings();
        }

        private async Task _GetCurrentUserSettings()
        {
            UserSettingsDto userSettings = await _UserSettingsClient.FindAsync("Current User");
            if (userSettings.UserInfo != null)
            {
                _CurrentUser = userSettings.UserInfo;

                if (_CurrentUser.Role == UserDto.enRole.Admin)
                {
                    tsbAdminSettings.Visible = true;
                }
                
            }
            else
            {
                MessageBox.Show("Ensure you have the necessary permissions to access this information.", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                EventLog.WriteEntry(clsUtility.sourceName, "User does not have the necessary permissions to access this information or not found.", EventLogEntryType.Error);

                // Close the form if the user is not found
                this.Close();
            }
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ShowAccountSettingsScreen()
        {
            frmCreateNewAccount frm = new frmCreateNewAccount(_CurrentUser.ID, _CurrentUser.Role, 0);
            frm.Show();
        }

        private void _ShowChangePasswordScreen()
        {
            frmCreateNewAccount frm = new frmCreateNewAccount(_CurrentUser.ID, _CurrentUser.Role, 1);
            frm.Show();
        }

        private async void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettingsDto userSettings = new UserSettingsDto();
            userSettings.Title = "Current User";
            userSettings.UserID = null;
            await _UserSettingsClient.UpdateUserSettingAsync(userSettings);
        }

        private void tsbLogoutSettings_Click(object sender, EventArgs e)
        {
            _ShowAccountSettingsScreen();
        }

        private void tsbChangePassword_Click(object sender, EventArgs e)
        {
            _ShowChangePasswordScreen();
        }
    }
}
