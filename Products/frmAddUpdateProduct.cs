using ApiClients.Api_URLs;
using ApiClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.ClientDtos;
using System.Drawing;
using ComputerStore_Business;
using Computer_Store.Properties;
using System.IO;
using System.Configuration;


namespace Computer_Store
{
    public partial class frmAddUpdateProduct : Form
    {
        // Event to notify when a product is saved
        public delegate void ProductSavedEventHandler(object sender, bool IsSaved);
        public event ProductSavedEventHandler ProductSaved;

        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private BrandsApiClient _BrandsClient = new BrandsApiClient(ApiUrls.BrandsURL);
        private CategoriesApiClient _CategoriesClient = new CategoriesApiClient(ApiUrls.CategoryURL);
        private SubcategoriesApiClient _SubcategoriesClient = new SubcategoriesApiClient(ApiUrls.SubcategoryURL);
        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);

        private enum enMode { AddNew = 0, Update = 1 }    
        private enMode _Mode;

        private ProductDto _ProductDto = new ProductDto();
        private List<ProductImageDto> _ProductImages = new List<ProductImageDto>();
        private int? _ProductID;

        private CategoryDto _Category;
        private SubcategoryDto _Subcategory;
        private BrandDto _Brand;


        public frmAddUpdateProduct(int? ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;

            if (_ProductID is null)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private async void frmAddUpdateProduct_Load(object sender, EventArgs e)
        {
            // Load brands, categories, and subcategories
            await _LoadCategoriesComboboxAsync();
            await _LoadBrandsComboboxAsync();

            cbxCategory.SelectedIndex = 0;
            cbxBrand.SelectedIndex = 0;

            await _LoadProductInfoAsync();
        }

        private async Task _LoadCategoriesComboboxAsync()
        {
            // Load categories into the combobox
            List<CategoryDto> categories = (List<CategoryDto>)await _CategoriesClient.GetAllAsync();
            cbxCategory.DataSource = categories;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "ID";
        }

        private async Task _LoadBrandsComboboxAsync()
        {
            // Load brands into the combobox
            List<BrandDto> brands = (List<BrandDto>)await _BrandsClient.GetAllAsync();
            cbxBrand.DataSource = brands;
            cbxBrand.DisplayMember = "Name";
            cbxBrand.ValueMember = "ID";
        }

        private async Task _LoadSubcategoryComboboxAsync(int? categoryID)
        {
            // Load subcategories into the combobox based on the selected category
            List<SubcategoryDto> subcategories = (List<SubcategoryDto>)await _SubcategoriesClient.GetSubcategoriesByCategoryID(categoryID);
            cbxSubcategory.DataSource = subcategories;
            cbxSubcategory.DisplayMember = "Name";
            cbxSubcategory.ValueMember = "ID";
        }

        private async Task _DisplayLoadInfoAsync()
        {
            txtProductName.Text = _ProductDto.Name;
            rtxtDescription.Text = _ProductDto.Description;
            txtPrice.Text = _ProductDto.Price.ToString();
            nudQuantityInStock.Value = (short)_ProductDto.QuantityInStock;
            dtpReleaseDate.Value = (DateTime)_ProductDto.ReleaseDate;

            if (_ProductID != null)
            {
                // Load product images for the existing product
                _ProductImages = (List<ProductImageDto>)await _ProductImagesClient.GetAllByProductIdAsync((int)_ProductID);
            }

            await _DisplayBrandCategorySubcategoryAsync();
            _DisplayProductImages();
        }

        private async Task _DisplayBrandCategorySubcategoryAsync()
        {
            // Display the selected brand, category, and subcategory
            BrandDto brand = await _BrandsClient.FindAsync(_ProductDto.BrandID);
            cbxBrand.SelectedIndex = cbxBrand.FindStringExact(brand.Name);

            CategoryDto category = await _CategoriesClient.FindAsync(_ProductDto.CategoryID);
            cbxCategory.SelectedIndex = cbxCategory.FindStringExact(category.Name);

            if (_ProductDto.SubcategoryID != null)
            {
                await _LoadSubcategoryComboboxAsync(_ProductDto.CategoryID);
                SubcategoryDto subcategory = await _SubcategoriesClient.FindAsync(_ProductDto.SubcategoryID);
                cbxSubcategory.SelectedIndex = cbxSubcategory.FindStringExact(subcategory.Name);
            }
            else
            {
                cbxSubcategory.SelectedItem = null;
            }
        }

        private void _DisplayProductImages()
        {
            // Load product images
            List<PictureBox> pictureBoxes = new List<PictureBox>() { pbImage1, pbImage2, pbImage3, pbImage4, pbImage5};
            List<Button> removeButtons = new List<Button>() { btnRemoveImage1, btnRemoveImage2, btnRemoveImage3, btnRemoveImage4, btnRemoveImage5 };

            //if (_ProductID != null)
            //{
            //    // Load product images for the existing product
            //    _ProductImages = (List<ProductImageDto>)await _ProductImagesClient.GetAllByProductIdAsync((int)_ProductID);
            //}

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                if (_ProductImages != null && i < _ProductImages.Count)
                {
                    //pictureBoxes[i].Image = System.Drawing.Image.FromFile(_ProductImages[i].ImagePath);
                    pictureBoxes[i].ImageLocation = _ProductImages[i].ImagePath;
                    _ProductImages[i].ImageOrder = (byte)(i + 1);
                    removeButtons[i].Visible = true;
                }
                else
                {
                    pictureBoxes[i].ImageLocation = null;
                    pictureBoxes[i].Image = Resources.addImage;
                    removeButtons[i].Visible = false;
                }
            }
        }

        private async Task _LoadProductInfoAsync()
        {
            if (_Mode == enMode.AddNew)
            {
                // Set the title for adding a new product
                lblTitle.Text = "Add New Product";
                this.Text = "Add New Product";
            }
            else
            {
                // Set the title for updating an existing product
                lblTitle.Text = "Update Product";
                this.Text = "Update Product";

                // Load the product details
                _ProductDto = await _ProductsClient.FindAsync(_ProductID);

                // Check if the product was found
                if (_ProductDto is null)
                {
                    MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                await _DisplayLoadInfoAsync();
            }
        }

        private async Task _SaveProductAsync()
        {
            _SetProductInfo();

            var product = await _ProductsClient.SaveAsync(_ProductDto);

            if (product is null)
            {
                // Handle error in saving product
                MessageBox.Show(gvMessages.errorSaveMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Delete old image and save new images for reset perpose

                // Delete existing product images
                if (_ProductID != null)
                {
                    await _ProductImagesClient.DeleteAllByProductIdAsync((int)_ProductID);
                }

                if (_ProductImages != null)
                {
                    // Save the product images
                    foreach (var productImage in _ProductImages)
                    {
                        productImage.ID = null; // Set ID to null for new images
                        productImage.ProductID = product.ID;
                        await _ProductImagesClient.SaveAsync(productImage);
                    }
                }
                MessageBox.Show(gvMessages.saveMessage("product"), "Saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Invoke the event to notify that the product has been saved
                ProductSaved?.Invoke(this, true);

                // Close the form
                this.Close();
            }
        }

        private void _SetProductInfo()
        {
            // Set the product information from the form fields
            _ProductDto.Name = txtProductName.Text;
            _ProductDto.Description = rtxtDescription.Text;
            _ProductDto.Price = decimal.Parse(txtPrice.Text);
            _ProductDto.QuantityInStock = (short)nudQuantityInStock.Value;
            _ProductDto.ReleaseDate = dtpReleaseDate.Value;
            // Set the selected brand, category, and subcategory
            BrandDto selectedBrand = (BrandDto)cbxBrand.SelectedItem;
            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            SubcategoryDto selectedSubcategory = (SubcategoryDto)cbxSubcategory.SelectedItem;
            _ProductDto.BrandID = (int)selectedBrand.ID;
            _ProductDto.CategoryID = (int)selectedCategory.ID;
            _ProductDto.SubcategoryID = selectedSubcategory?.ID;
        }

        private void _ChooseImageFromFile()
        {
            // Prepare openFileDialog
            openFileDialogForImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.webp";
            openFileDialogForImage.FilterIndex = 1;
            openFileDialogForImage.RestoreDirectory = true;// Save last directorty

            if (openFileDialogForImage.ShowDialog() == DialogResult.OK)
            {
                List<PictureBox> pictureBoxes = new List<PictureBox>() { pbImage1, pbImage2, pbImage3, pbImage4, pbImage5 };
                List<Button> removeButtons = new List<Button>() { btnRemoveImage1, btnRemoveImage2, btnRemoveImage3, btnRemoveImage4, btnRemoveImage5 };

                for (int i = 0; i < pictureBoxes.Count; i++)
                {
                    if (string.IsNullOrEmpty(pictureBoxes[i].ImageLocation))
                    {
                        //pictureBoxes[i].Image = System.Drawing.Image.FromFile(openFileDialogForImage.FileName);
                        pictureBoxes[i].ImageLocation = openFileDialogForImage.FileName;

                        // Set image path and order
                        ProductImageDto productImage = new ProductImageDto();
                        productImage.ImagePath = openFileDialogForImage.FileName;
                        productImage.ImageOrder = (byte)(i + 1);
                        if (_ProductImages is null)
                        {
                            _ProductImages = new List<ProductImageDto>();
                        }
                        _ProductImages.Add(productImage);

                        // Set image path for saving
                        _SetPersonImagePath(i);
                        removeButtons[i].Visible = true;

                        break;
                    }
                }
                //if (productImage.ImagePath != null)
                //{
                //    _RemovePersonImage();
                //}

                //Display person image
                //string SelectedPath = openFileDialogForImage.FileName;
                //pbImage.Load(SelectedPath);


                // Show remove link label
            }
        }

        private void _SetPersonImagePath(int index)
        {
            // Set Imagepath if does not have default image
            string SourceFilePath = _ProductImages[index].ImagePath;

            if (SourceFilePath != null)
            {
                string Extension = Path.GetExtension(SourceFilePath);
                string ProductImageDirectory = ConfigurationManager.AppSettings["ProductImageDirectory"];
                string DestinationFilePath = Path.Combine(ProductImageDirectory, $"{Guid.NewGuid()}{Extension}");

                File.Copy(SourceFilePath, DestinationFilePath, true);
                _ProductImages[index].ImagePath = DestinationFilePath;
            }
            else
            {
                _ProductImages[index].ImagePath = null;
            }
        }

        private void _RemoveProductImage(ProductImageDto productImage)
        {
            // Remove image path if it is default image
            string SourceFilePath = productImage.ImagePath;
            List<PictureBox> pictureBoxes = new List<PictureBox>() { pbImage1, pbImage2, pbImage3, pbImage4, pbImage5 };

            if (SourceFilePath != null)
            {
                try
                {
                    // Remove image path
                    int index = (int)productImage.ImageOrder - 1;
                    pictureBoxes[index].ImageLocation = null;
                    pictureBoxes[index].Image = Resources.addImage;
                    _ProductImages.RemoveAt(index);

                    File.Delete(SourceFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Reset images for products
            _DisplayProductImages();
        }

        private void _ShowCategoryUI()
        {
            lblCategoryName.Visible = true;
            txtCategoryName.Visible = true;
            btnSaveCategory.Visible = true;
            btnCancelCategory.Visible = true;

        }

        private void _ShowSubcategoryUI()
        {
            lblSubcategoryName.Visible = true;
            txtSubcategoryName.Visible = true;
            btnSaveSubcategory.Visible = true;
            btnCancelSubcategory.Visible = true;
        }

        private void _ShowBrandUI()
        {
            lblBrandName.Visible = true;
            txtBrandName.Visible = true;
            btnSaveBrand.Visible = true;
            btnCancelBrand.Visible = true;
        }

        private void _HideCategoryUI()
        {
            lblCategoryName.Visible = false;
            txtCategoryName.Visible = false;
            btnSaveCategory.Visible = false;
            btnCancelCategory.Visible = false;

            txtCategoryName.Clear();
        }

        private void _HideSubcategoryUI()
        {
            lblSubcategoryName.Visible = false;
            txtSubcategoryName.Visible = false;
            btnSaveSubcategory.Visible = false;
            btnCancelSubcategory.Visible = false;

            txtSubcategoryName.Clear();

        }

        private void _HideBrandUI()
        {
            lblBrandName.Visible = false;
            txtBrandName.Visible= false;
            btnSaveBrand.Visible = false;
            btnCancelBrand.Visible = false;

            txtBrandName.Clear();
        }

        private void _AddNewCategory()
        {
            _ShowCategoryUI();
            _Category = new CategoryDto();
        }

        private void _AddNewSubcategory()
        {
            _ShowSubcategoryUI();
            _Subcategory = new SubcategoryDto();
        }

        private void _AddNewBrand()
        {
            _ShowBrandUI();
            _Brand = new BrandDto();
        }

        private async Task _UpdateCategoryAsync()
        {
            _ShowCategoryUI();

            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            int selectedCategoryID = (int)selectedCategory.ID;

            _Category = await _CategoriesClient.FindAsync(selectedCategoryID);

            // Display the selected category name in the text box
            txtCategoryName.Text = _Category.Name;
        }

        private async Task _UpdateSubcategoryAsync()
        {
            _ShowSubcategoryUI();

            SubcategoryDto selectedSubcategory = (SubcategoryDto)cbxSubcategory.SelectedItem;
            int selectedSubcategoryID = (int)selectedSubcategory.ID;

            _Subcategory = await _SubcategoriesClient.FindAsync(selectedSubcategoryID);

            // Display the selected subcategory name in the text box
            txtSubcategoryName.Text = _Subcategory.Name;
        }

        private async Task _UpdateBrandAsync()
        {
            _ShowBrandUI();
            BrandDto selectedBrand = (BrandDto)cbxBrand.SelectedItem;
            int selectedBrandID = (int)selectedBrand.ID;

            _Brand = await _BrandsClient.FindAsync(selectedBrandID);

            // Display the selected brand name in the text box
            txtBrandName.Text = _Brand.Name;
        }

        private async Task _DeleteCategoryAsync()
        {
            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            int selectedCategoryID = (int)selectedCategory.ID;

            if (MessageBox.Show(gvMessages.askForDeleteMessage("category"), "Delete?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _CategoriesClient.DeleteAsync(selectedCategoryID);
                if (result)
                {
                    // Category deleted successfully
                    MessageBox.Show(gvMessages.deleteMessage("category"), "Deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadCategoriesComboboxAsync();
                }
                else
                {
                    // Handle error in deleting category
                    MessageBox.Show(gvMessages.errorDeleteMessage + " Or there are related with existing product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task _DeleteSubcategoryAsync()
        {
            SubcategoryDto selectedSubcategory = (SubcategoryDto)cbxSubcategory.SelectedItem;
            int selectedSubcategoryID = (int)selectedSubcategory.ID;
            if (MessageBox.Show(gvMessages.askForDeleteMessage("subcategory"), "Delete?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _SubcategoriesClient.DeleteAsync(selectedSubcategoryID);
                if (result)
                {
                    // Subcategory deleted successfully
                    MessageBox.Show(gvMessages.deleteMessage("subcategory"), "Deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadSubcategoryComboboxAsync(selectedSubcategory.CategoryID);
                }
                else
                {
                    // Handle error in deleting subcategory
                    MessageBox.Show(gvMessages.errorDeleteMessage + " Or there are related with existing product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task _DeleteBrandAsync()
        {
            BrandDto selectedBrand = (BrandDto)cbxBrand.SelectedItem;
            int selectedBrandID = (int)selectedBrand.ID;
            if (MessageBox.Show(gvMessages.askForDeleteMessage("brand"), "Delete?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _BrandsClient.DeleteAsync(selectedBrandID);
                if (result)
                {
                    // Brand deleted successfully
                    MessageBox.Show(gvMessages.deleteMessage("brand"), "Deleted successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadBrandsComboboxAsync();
                }
                else
                {
                    // Handle error in deleting brand
                    MessageBox.Show(gvMessages.errorDeleteMessage + " Or there are related with existing product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task _SaveCategoryAsync()
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the category name
            if (await _IsCategoryExistAsync(txtCategoryName.Text))
            {
                MessageBox.Show("Category name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // If validation fails, exit the method
            }

            // Set the category name
            _Category.Name = txtCategoryName.Text;
            var category = await _CategoriesClient.SaveAsync(_Category);
            if (category is null)
            {
                // Handle error in saving category
                MessageBox.Show(gvMessages.errorSaveMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Category saved successfully
                MessageBox.Show(gvMessages.saveMessage("category"), "Saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                await _LoadCategoriesComboboxAsync();

                _HideCategoryUI();
            }
        }

        private async Task _SaveSubcategoryAsync()
        {
            if (string.IsNullOrEmpty(txtSubcategoryName.Text))
            {
                MessageBox.Show("Please enter a subcategory name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;

            _Subcategory.CategoryID = selectedCategory.ID;

            // Validate the subcategory name
            if (await _IsSubcategoryExistAsync(txtSubcategoryName.Text, _Subcategory?.CategoryID))
            {
                MessageBox.Show("Subcategory name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // If validation fails, exit the method
            }

            // Set the subcategory name and category ID
            _Subcategory.Name = txtSubcategoryName.Text;
            
            var subcategory = await _SubcategoriesClient.SaveAsync(_Subcategory);
            if (subcategory is null)
            {
                // Handle error in saving subcategory
                MessageBox.Show(gvMessages.errorSaveMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Subcategory saved successfully
                MessageBox.Show(gvMessages.saveMessage("subcategory"), "Saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await _LoadSubcategoryComboboxAsync(_Subcategory.CategoryID);

                _HideSubcategoryUI();
            }
        }

        private async Task _SaveBrandAsync()
        {
            if (string.IsNullOrEmpty(txtBrandName.Text))
            {
                MessageBox.Show("Please enter a brand name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the brand name
            if (await _IsBrandExistAsync(txtBrandName.Text))
            {
                MessageBox.Show("Brand name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // If validation fails, exit the method
            }

            // Set the brand name
            _Brand.Name = txtBrandName.Text;
            var brand = await _BrandsClient.SaveAsync(_Brand);
            if (brand is null)
            {
                // Handle error in saving brand
                MessageBox.Show(gvMessages.errorSaveMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Brand saved successfully
                MessageBox.Show(gvMessages.saveMessage("brand"), "Saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await _LoadBrandsComboboxAsync();

                _HideBrandUI();
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

        private bool _ValidateRequiredField(RichTextBox ctrl, string name)
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

        private bool _IsValidData()
        {
            // Validate required fields
            bool isValid = true;
            isValid &= _ValidateRequiredField(txtProductName, "product name");
            isValid &= _ValidateRequiredField(rtxtDescription, "description");
            isValid &= _ValidateRequiredField(txtPrice, "price");
           
            return isValid;
        }

        private async Task<bool> _IsCategoryExistAsync(string categoryName)
        {
            // Check if the category already exists
            var existingCategory = await _CategoriesClient.IsExistAsync(categoryName);
            return existingCategory;
        }

        private async Task<bool> _IsSubcategoryExistAsync(string subcategoryName, int? categoryID)
        {
            // Check if the subcategory already exists
            SubcategoryDto subcategory = new SubcategoryDto
            {
                Name = subcategoryName,
                CategoryID = categoryID
            };
            var existingSubcategory = await _SubcategoriesClient.IsExistAsync(subcategory);
            return existingSubcategory;
        }

        private async Task<bool> _IsBrandExistAsync(string brandName)
        {
            // Check if the brand already exists
            var existingBrand = await _BrandsClient.IsExistAsync(brandName);
            return existingBrand;
        }

        private async void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            int selectedCategoryID = (int)selectedCategory.ID;
            await _LoadSubcategoryComboboxAsync(selectedCategoryID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvMessages.askForSaveMessage("product"), "Save?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Validate required fields
                if (!_IsValidData())
                {
                    MessageBox.Show(gvMessages.errorProviderMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await _SaveProductAsync();
            }
        }

        private void btnRemoveImage1_Click(object sender, EventArgs e)
        {
            _RemoveProductImage(_ProductImages[0]);
        }

        private void btnRemoveImage2_Click(object sender, EventArgs e)
        {
            _RemoveProductImage(_ProductImages[1]);
        }

        private void btnRemoveImage3_Click(object sender, EventArgs e)
        {
            _RemoveProductImage(_ProductImages[2]);
        }

        private void btnRemoveImage4_Click(object sender, EventArgs e)
        {
            _RemoveProductImage(_ProductImages[3]);
        }

        private void btnRemoveImage5_Click(object sender, EventArgs e)
        {
            _RemoveProductImage(_ProductImages[4]);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            _ChooseImageFromFile();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            _AddNewCategory();
        }

        private async void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvMessages.askForSaveMessage("category"), "Save?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _SaveCategoryAsync();
            }
        }

        private void btnAddSubcategory_Click(object sender, EventArgs e)
        {
            _AddNewSubcategory();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            _AddNewBrand();
        }

        private async void btnSaveSubcategory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvMessages.askForSaveMessage("subcategory"), "Save?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _SaveSubcategoryAsync();
            }
        }

        private async void btnSaveBrand_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(gvMessages.askForSaveMessage("brand"), "Save?"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _SaveBrandAsync();
            }
        }

        private void btnCancelCategory_Click(object sender, EventArgs e)
        {
            _HideCategoryUI();
        }

        private void btnCancelSubcategory_Click(object sender, EventArgs e)
        {
            _HideSubcategoryUI();
        }

        private void btnCancelBrand_Click(object sender, EventArgs e)
        {
            _HideBrandUI();
        }

        private async void btnEditCategory_Click(object sender, EventArgs e)
        {
            await _UpdateCategoryAsync();
        }

        private async void btnEditSubcategory_Click(object sender, EventArgs e)
        {
            await _UpdateSubcategoryAsync();
        }

        private async void btnEditBrand_Click(object sender, EventArgs e)
        {
            await _UpdateBrandAsync();
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            await _DeleteCategoryAsync();
        }

        private async void btnDeleteSubcategory_Click(object sender, EventArgs e)
        {
            await _DeleteSubcategoryAsync();
        }

        private async void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            await _DeleteBrandAsync();
        }
    }
}
