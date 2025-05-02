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
        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiUrls.OrdersURL);
        private OrderItemsApiClient _OrderItemsClient = new OrderItemsApiClient(ApiUrls.OrderItemsURL);

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
        private int _UserID;

        public ctrlProduct()
        {
            InitializeComponent();
        }

        public async Task LoadProductInfo(ProductDto product, int userID)
        {
            // show product
            this.Visible = true;

            pbProductImage.ImageLocation = null;
            pbProductImage.Image = Resources.No_Image;

            _UserID = userID;

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

        private async Task _DisplayProductQuantity()
        {
            short? quantity = _Product.QuantityInStock;

            // check quantity added before
            var order = await _OrdersClient.FindCurrentAsync(_UserID);
            if (order != null &&  order.OrderID != null)
            {
                var orderItem = await _OrderItemsClient.FindAsync(new OrderItemKeyDto(order.OrderID, _Product.ID));
                if (orderItem != null && orderItem.Quantity != null)
                {
                    quantity -= orderItem.Quantity;
                }
            }

            if (quantity > 0)
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
            lblProductPrice.Text = clsUtility.DecimalToMoneyString(_Product.Price);

            // Display product rating 
            ctrlStarsRating.DisplayRating(_Product.Rating);

            await Task.WhenAll(_DisplayProductImage(),_DisplayProductQuantity());
        }

    }
}
