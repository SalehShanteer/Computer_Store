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
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Configuration;
using System.Runtime.CompilerServices;

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
            await _LoadCategoriesCombobox();
            await _LoadBrandsCombobox();

            cbxCategory.SelectedIndex = 0;
            cbxBrand.SelectedIndex = 0;

            await _LoadProductInfo();
        }

        private async Task _LoadCategoriesCombobox()
        {
            // Load categories into the combobox
            List<CategoryDto> categories = (List<CategoryDto>)await _CategoriesClient.GetAllAsync();
            cbxCategory.DataSource = categories;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "ID";
        }

        private async Task _LoadBrandsCombobox()
        {
            // Load brands into the combobox
            List<BrandDto> brands = (List<BrandDto>)await _BrandsClient.GetAllAsync();
            cbxBrand.DataSource = brands;
            cbxBrand.DisplayMember = "Name";
            cbxBrand.ValueMember = "ID";
        }

        private async Task _LoadSubcategoryCombobox(int? categoryID)
        {
            // Load subcategories into the combobox based on the selected category
            List<SubcategoryDto> subcategories = (List<SubcategoryDto>)await _SubcategoriesClient.GetSubcategoriesByCategoryID(categoryID);
            cbxSubcategory.DataSource = subcategories;
            cbxSubcategory.DisplayMember = "Name";
            cbxSubcategory.ValueMember = "ID";
        }

        private async Task _DisplayLoadInfo()
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

            await _DisplayBrandCategorySubcategory();
            _DisplayProductImages();
        }

        private async Task _DisplayBrandCategorySubcategory()
        {
            // Display the selected brand, category, and subcategory
            cbxBrand.SelectedItem = await _BrandsClient.FindAsync(_ProductDto.BrandID);
            cbxCategory.SelectedItem = await _CategoriesClient.FindAsync(_ProductDto.CategoryID);
            if (_ProductDto.SubcategoryID != null)
            {
                await _LoadSubcategoryCombobox(_ProductDto.CategoryID);
                cbxSubcategory.SelectedItem = await _SubcategoriesClient.FindAsync(_ProductDto.SubcategoryID);
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

        private async Task _LoadProductInfo()
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

                await _DisplayLoadInfo();
            }
        }

        private async Task _SaveProduct()
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
            openFileDialogForImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
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

        private async void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)cbxCategory.SelectedItem;
            int selectedCategoryID = (int)selectedCategory.ID;
            await _LoadSubcategoryCombobox(selectedCategoryID);
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
                await _SaveProduct();
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
    }
}
