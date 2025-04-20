using ApiClients.Api_URLs;
using ApiClients;
using ApiClients.ClientDtos;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlOrderItemViewer : UserControl
    {

        private ProductImagesApiClient _ProductImagesClient = new ProductImagesApiClient(ApiUrls.ProductImagesURL);
        private OrderItemsApiClient _OrderItemClient = new OrderItemsApiClient(ApiUrls.OrderItemsURL);
        private ProductsApiClient _ProductsClient = new ProductsApiClient(ApiUrls.ProductsURL);

        private OrderItemDto _OrderItem;

        public int? OrderID
        {
            get
            {
                if (_OrderItem == null)
                {
                    return null;
                }
                return _OrderItem.OrderID;
            }
        }

        public int? ProductID
        {
            get
            {
                if (_OrderItem == null)
                {
                    return null;
                }
                return _OrderItem.ProductID;
            }
        }     

        public int? Quantity
        {
            get
            {
                if (_OrderItem == null)
                {
                    return null;
                }
                return _OrderItem.Quantity;
            }
        }

        public ctrlOrderItemViewer()
        {
            InitializeComponent();
        }

        public async Task LoadOrderItem(OrderItemDto orderItem)
        {
            if (orderItem is null)
            {
                MessageBox.Show("The order item is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _OrderItem = orderItem;

            await _DisplayOrderItem();
        }

        private async Task _DisplayOrderItemImage()
        {
            int? productID = _OrderItem.ProductID;

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

        private async Task _GetProductName(int? productID)
        {
            if (productID != null)
            {
                // Get the product name
                ProductDto product = await _ProductsClient.FindAsync(productID.Value);
                if (product != null)
                {
                    lblName.Text = product.Name;
                }
            }
        }

        private async Task _DisplayOrderItem()
        {
            lblQuantity.Text =  _OrderItem.Quantity.ToString();
            lblOneItemPrice.Text = clsUtility.DecimalToMoneyString(_OrderItem.Price);
            lblTotalItemsPrice.Text = clsUtility.DecimalToMoneyString(_OrderItem.TotalItemsPrice);
            lblProductID.Text = _OrderItem.ProductID.ToString();

            await Task.WhenAll(_DisplayOrderItemImage(), _GetProductName(_OrderItem.ProductID));
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //raise event to remove the order item
        }
    }
}
