using ApiClients.Api_URLs;
using ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.ClientDtos;
using Computer_Store.Properties;

namespace Computer_Store
{
    public partial class frmProductViewer : Form
    {

        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);
        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);

        private int? _ProductID;
        private ProductDetailsDto _Product;
        private List<string> _ProductImagePaths;

        public frmProductViewer(int? productID)
        {
            InitializeComponent();


            if (productID is null || productID < 1)
            {
                MessageBox.Show("Invalid Product ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close the form if the product ID is invalid
                this.Close();
            }

            _ProductID = productID;
        }

        private async void frmProductViewer_Load(object sender, EventArgs e)
        {
            await _LoadProductDetails();
        }

        private async Task _LoadProductDetails()
        {
            _Product = await _ProductsClient.FindWithDetailsAsync(_ProductID);
            
            if (_Product == null)
            {
                MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await _LoadImagesPaths();
            _DisplayProductDetails();
        }

        private async Task _LoadImagesPaths()
        {
            // Load image paths from the product images
            _ProductImagePaths = new List<string>();
            List<ProductImageDto> productImages = (List<ProductImageDto>)await _ProductImagesClient.GetAllByProductIdAsync((int)_Product.ID);

            foreach (var image in productImages)
            {
                _ProductImagePaths.Add(image.ImagePath);
            }
        }

        private void _DisplayProductsImages(byte imageOrder)
        {
            if (_ProductImagePaths != null && _ProductImagePaths.Count > imageOrder - 1)
            {
                // Display the first image in the list
                string imagePath = _ProductImagePaths[imageOrder - 1];
                pbProductImage.ImageLocation = imagePath;
            }
            else
            {
                pbProductImage.ImageLocation = null;
                pbProductImage.Image = Resources.No_Image;
            }
        }

        private void _DisplayProductDetails()
        {
            // Display product details
            lblProductName.Text = _Product.Name;
            lblProductPrice.Text = (_Product.Price?.ToString("F2") ?? "0.00") + "$";
            lblDescription.Text = _Product.Description;
            lblCategory.Text = _Product.Category;
            lblSubcategory.Text = _Product.Subcategory;
            lblBrand.Text = _Product.Brand;

            // Display product rating as stars
            ctrlStarsRating.DisplayRating(_Product.Rating);

            _DisplayProductQuantity();
            _DisplayProductsImages(1);
        }

        private void _DisplayProductQuantity()
        {
            short? quantity = _Product.QuantityInStock;

            if (quantity != 0)
            {
                lblProductInStock.Text = $"{quantity} left";
                lblProductInStock.ForeColor = Color.Green;
            }
            else
            {
                lblProductInStock.Text = "Out of stock";
                lblProductInStock.ForeColor = Color.Red;
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
