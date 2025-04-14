using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmMain : Form
    {
        private UserDto _CurrentUser;
        private UserSettingsApiClient _UserSettingsClient = new UserSettingsApiClient(ApiUrls.UserSettingsURL);
        private BrandsApiClient _BrandsClient = new BrandsApiClient(ApiUrls.BrandsURL);
        private CategoriesApiClient _CategoriesClient = new CategoriesApiClient(ApiUrls.CategoryURL);
        private SubcategoriesApiClient _SubcategoriesClient = new SubcategoriesApiClient(ApiUrls.SubcategoryURL);
        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private List<ProductDto> _Products;

        private int _PageNumber = 1;

        public frmMain()
        {
            InitializeComponent();

            // Subscribe to the event handlers
            ctrlProduct1.Click += ctrlProduct_Click;
            ctrlProduct2.Click += ctrlProduct_Click;
            ctrlProduct3.Click += ctrlProduct_Click;
            ctrlProduct4.Click += ctrlProduct_Click;
            ctrlProduct5.Click += ctrlProduct_Click;
            ctrlProduct6.Click += ctrlProduct_Click;
            ctrlProduct7.Click += ctrlProduct_Click;
            ctrlProduct8.Click += ctrlProduct_Click;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await _GetCurrentUserSettings();
            await _LoadProducts();

            await _LoadCategoriesCombobox();
            await _LoadBrandsCombobox();
        }

        private async Task _LoadProducts()
        {
            // Load products
            _Products = (List<ProductDto>)await _ProductsClient.GetAllAsync();
            _UpdatePageNavigator();
            await _DisplayProducts(1);
        }   

        private async Task _LoadFilteredProducts(ProductFilterDto filter)
        {
            // Load products
            _Products = (List<ProductDto>)await _ProductsClient.GetAllFilteredAsync(filter);
            _UpdatePageNavigator();
            await _DisplayProducts(1);
        }

        private void _UpdatePageNavigator()
        {
            int productCount = 0;
            if (_Products != null)
            {
                productCount = _Products.Count;
            }
            ctrlPageNavigator1.UpdateNumberOfPages(productCount);
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
            int productsNumber = 0;

            // Check if the product list is null or empty
            if (_Products != null)
            {
                productsNumber = _Products.Count;

                // Check if the product number is within the range of the product list
                lblNoResult.Visible = false;
            }
            else
            {
                // If the product list is null or empty, show the no result label
                lblNoResult.Visible = true;
            }

            if (productNumber < productsNumber)
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

        private async Task _LoadCategoriesCombobox()
        {
            // Load categories into the combobox
            List<CategoryDto> categories = (List<CategoryDto>)await _CategoriesClient.GetAllAsync();

            // Create a default item
            var defaultItem = new CategoryDto
            {
                ID = -1, // Use a value that won't conflict with real categories
                Name = "-- Select Category --"
            };

            // Insert default item at beginning
            categories.Insert(0, defaultItem);
            cbxCategory.DataSource = categories;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "ID";
        }

        private async Task _LoadBrandsCombobox()
        {
            // Load brands into the combobox
            List<BrandDto> brands = (List<BrandDto>)await _BrandsClient.GetAllAsync();

            // Create a default item
            var defaultItem = new BrandDto
            {
                ID = -1, // Use a value that won't conflict with real brands
                Name = "-- Select Brand --"
            };
            // Insert default item at beginning
            brands.Insert(0, defaultItem);
            cbxBrand.DataSource = brands;
            cbxBrand.DisplayMember = "Name";
            cbxBrand.ValueMember = "ID";
        }

        private async Task _LoadSubcategoryCombobox(int? categoryID)
        {
            // Load subcategories into the combobox based on the selected category
            List<SubcategoryDto> subcategories = (List<SubcategoryDto>)await _SubcategoriesClient.GetSubcategoriesByCategoryID(categoryID);
            // Create a default item
            var defaultItem = new SubcategoryDto(-1, "-- Select Subcategory --", -1);

            // Insert default item at beginning
            subcategories.Insert(0, defaultItem);

            cbxSubcategory.DataSource = subcategories;
            cbxSubcategory.DisplayMember = "Name";
            cbxSubcategory.ValueMember = "ID";
        }

        private async Task _MainFilter(int productCategoryID)
        {
            ProductFilterDto productFilter = new ProductFilterDto();
            productFilter.CategoryID = productCategoryID;
            await _LoadFilteredProducts(productFilter);

            // Load the category name into the combobox
            CategoryDto category = await _CategoriesClient.FindAsync(productCategoryID);
            cbxCategory.SelectedIndex = cbxCategory.FindStringExact(category.Name);
        }

        private ProductFilterDto _SetFilter()
        {
            ProductFilterDto productFilter = new ProductFilterDto();
            string Name = !string.IsNullOrWhiteSpace(txtSearch.Text) ? txtSearch.Text.Trim() : null;
            int? categoryID = (int)cbxCategory.SelectedValue != -1 ? (int?)cbxCategory.SelectedValue : null;
            int? subcategoryID = (int?)cbxSubcategory.SelectedValue != null && (int)cbxSubcategory.SelectedValue != -1 ? (int?)cbxSubcategory.SelectedValue : null;
            int? brandID = (int)cbxBrand.SelectedValue != -1 ? (int?)cbxBrand.SelectedValue : null;
            decimal? minPrice = !string.IsNullOrWhiteSpace(txtMinPrice.Text) ? (decimal?)Convert.ToInt32(txtMinPrice.Text) : null;
            decimal? maxPrice = !string.IsNullOrWhiteSpace(txtMaxPrice.Text) ? (decimal?)Convert.ToInt32(txtMaxPrice.Text) : null;

            productFilter.Name = Name;
            productFilter.CategoryID = categoryID;
            productFilter.SubCategoryID = subcategoryID;
            productFilter.BrandID = brandID;
            productFilter.MinPrice = minPrice;
            productFilter.MaxPrice = maxPrice;

            return productFilter;
        }

        private async Task _FilterProducts()
        {
            ProductFilterDto productFilter = _SetFilter();
            await _LoadFilteredProducts(productFilter);
        }

        private void _ShowProductScreen(int? productID)
        {
            frmProductViewer frm = new frmProductViewer(productID);
            //frm.FormClosed += (s, e) =>
            //{
            //    this.Focus(); // Focus on close
            //};
            frm.Show(); // Non-blocking
        }

        private void _ShowAddAdminScreen()
        {
            frmCreateNewAccount frm = new frmCreateNewAccount(null, UserDto.enRole.Admin, 0);
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

        private async  void ctrlPageNavigator1_OnPageChange(object sender, int PageNumber)
        {
            _PageNumber = PageNumber;
            await _DisplayProducts(_PageNumber);
        }

        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageProductsScreen();
        }

        private async void tsbLaptop_Click(object sender, EventArgs e)
        {
            await _MainFilter(1); // Laptop category id = 1
        }

        private async void tsbDesktop_Click(object sender, EventArgs e)
        {
            await _MainFilter(13); // Desktop category id = 13
        }

        private async void tsbMonitor_Click(object sender, EventArgs e)
        {
            await _MainFilter(3); // Monitor category id = 3
        }

        private async void tsbComponents_Click(object sender, EventArgs e)
        {
            await _MainFilter(14); // Components category id = 14
        }

        private async void tsbStorage_Click(object sender, EventArgs e)
        {
            await _MainFilter(17); // Storage category id = 17
        }

        private async void tsbAccessories_Click(object sender, EventArgs e)
        {
            await _MainFilter(16); // Accessories category id = 16
        }

        private async void tsbHeadset_Click(object sender, EventArgs e)
        {
            await _MainFilter(15); // Headset category id = 15
        }

        private void txtMinPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && !txtMinPrice.Text.Contains('.'))
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }   
            
            else if (txtMinPrice.Text.Contains('.') && !char.IsControl(e.KeyChar))
            {
                int indexOfDot = txtMinPrice.Text.IndexOf('.');
                if (txtMinPrice.TextLength - indexOfDot > 2)
                {
                    e.Handled = true; // Prevent more than 2 decimal places
                }
            }
        }

        private void txtMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && !txtMaxPrice.Text.Contains('.'))
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (txtMaxPrice.Text.Contains('.') && !char.IsControl(e.KeyChar))
            {
                int indexOfDot = txtMaxPrice.Text.IndexOf('.');
                if (txtMaxPrice.TextLength - indexOfDot > 2)
                {
                    e.Handled = true; // Prevent more than 2 decimal places
                }
            }
        }

        private async void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            int selectedCategoryID = (int)selectedCategory.ID;
            if (selectedCategoryID > 0)
            {
                await _LoadSubcategoryCombobox(selectedCategoryID);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await _FilterProducts();
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            await _LoadProducts();
        }

        private void ctrlProduct_Click(object sender, EventArgs e)
        {
            ctrlProduct product = (ctrlProduct)sender;
            _ShowProductScreen(product.ProductID);
        }

        private void tsbAddNewAdmin_Click(object sender, EventArgs e)
        {
            _ShowAddAdminScreen();
        }
    }
}
