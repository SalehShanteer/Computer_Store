using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using Computer_Store.Properties;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlProduct : UserControl
    {

        private ProductDto _Product;
        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);

        public int? ProductID
        {
            get
            {
                if (_Product == null)
                {
                    return null;
                }
                return _Product.ID;
            }
        }

        public ctrlProduct()
        {
            InitializeComponent();
        }

        public async Task LoadProductInfo(ProductDto product)
        {
            // show product
            this.Visible = true;

            pbProductImage.ImageLocation = null;
            pbProductImage.Image = Resources.No_Image;

            if (product != null)
            {
                _Product = product;
                await _DisplayProduct();
            }
        }

        public void HideProduct()
        {
            // Hide product
            this.Visible = false;       
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

        private async Task _DisplayProductImage()
        {
            int? productID = _Product.ID;

            if (productID != null)
            {
                // Get the first image for the product
                ProductImageDto productImage = await _ProductImagesClient.FindFirstImageByProductIdAsync(productID.Value);
                if (productImage != null)
                {
                    // Load the image from the file path
                    string imagePath = productImage.ImagePath;
                    if (imagePath != null)
                    {
                        pbProductImage.ImageLocation = imagePath;
                    }
                }
            }
        }

        private async Task _DisplayProduct()
        {
            lblProductID.Text = _Product.ID.ToString();
            lblProductName.Text = _Product.Name;
            lblProductPrice.Text = (_Product.Price?.ToString("F2") ?? "0.00") + "$";
            _DisplayProductQuantity();

            // Display product rating 
            ctrlStarsRating.DisplayRating(_Product.Rating);

            await _DisplayProductImage();
        }

      
    }
}
