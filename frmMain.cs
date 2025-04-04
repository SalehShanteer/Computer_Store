using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmMain : Form
    {
        private UserDto _CurrentUser;
        private UserSettingsApiClient _UserSettingsClient = new UserSettingsApiClient(ApiUrls.UserSettingsURL);

        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private List<ProductDto> _Products;

        private int _PageNumber = 1;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await _GetCurrentUserSettings();
            await _LoadProducts();
        }

        private async Task _LoadProducts()
        {
            // Load products
            _Products = (List<ProductDto>)await _ProductsClient.GetAllAsync();
            _UpdatePageNavigator();
            await _DisplayProducts(1);
        }

        private void _UpdatePageNavigator()
        {
            ctrlPageNavigator1.UpdateNumberOfPages(_Products.Count);

        }

        private async Task _DisplayProducts(int pageNumber)
        {
            // Multiplier to to specify the product by page
            int multiplier = (pageNumber - 1) * 8;

            List<ctrlProduct> products = new List<ctrlProduct> { ctrlProduct1, ctrlProduct2, ctrlProduct3
                , ctrlProduct4, ctrlProduct5, ctrlProduct6, ctrlProduct7, ctrlProduct8};

            int count = 0;
            for (int i = multiplier; i < multiplier + 8; i++)
            {
                // Load product one by one 
                await _LoadOneProduct(i, products[count]);
                count++;
            }       
        }

        private async Task _LoadOneProduct(int productNumber, ctrlProduct product)
        {
            if (productNumber < _Products.Count)
            {
                await product.LoadProductInfo(_Products[productNumber]);
            }
            else
            {
                product.HideProduct();
            }
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

        private void _ShowManageProductsScreen()
        {
            frmManageProducts frm = new frmManageProducts();
            frm.FormClosed += async (s, e) =>
            {
                this.Focus(); // Focus on close
                await _LoadProducts(); // Refresh after form closes
            };
            frm.Show(); // Non-blocking
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

        private async  void ctrlPageNavigator1_OnPageChange(object sender, int PageNumber)
        {
            _PageNumber = PageNumber;
            await _DisplayProducts(_PageNumber);
        }

        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageProductsScreen();
        }
    }
}
