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
        private short? _ProductQuantity; 
        private short? _SelectedQuantity; // The quantity selected by the user

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
                return _OrderItem.Quantity + _ProductQuantity - _SelectedQuantity;
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

        private async Task _DisplayOrderItem()
        {
            // Set the order item quantity
            lblQuantity.Text =  _OrderItem.Quantity.ToString();
            _SelectedQuantity = _OrderItem.Quantity;

            lblOneItemPrice.Text = clsUtility.DecimalToMoneyString(_OrderItem.Price);
            lblTotalItemsPrice.Text = clsUtility.DecimalToMoneyString(_OrderItem.TotalItemsPrice);
            lblProductID.Text = _OrderItem.ProductID.ToString();

            var product = await _ProductsClient.FindAsync(_OrderItem.ProductID.Value);

            if (product != null)
            {
                // Set the product name
                lblName.Text = product.Name;

                // Set the product quantity
                _ProductQuantity = product.QuantityInStock;
            }

            await _DisplayOrderItemImage();
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to remove this item from the order?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //raise event to remove the order item
            }
        }

        private void _UpdateOrderItemUI()
        {
            lblQuantity.Text = _SelectedQuantity.ToString();
            lblTotalItemsPrice.Text = clsUtility.DecimalToMoneyString(_OrderItem.Price * _SelectedQuantity);
        }

        private void pbAdd_Click(object sender, System.EventArgs e)
        {
            if (_SelectedQuantity < _ProductQuantity)
            {
                _SelectedQuantity++;
                _UpdateOrderItemUI();
            }
        }

        private void pbSub_Click(object sender, System.EventArgs e)
        {
            if (_SelectedQuantity > 1)
            {
                _SelectedQuantity--;
                _UpdateOrderItemUI();
            }
        }

        private void pbSub_MouseHover(object sender, System.EventArgs e)
        {
            // Change the background color of the subtract button to indicate hover
            pbSub.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void pbAdd_MouseHover(object sender, System.EventArgs e)
        {
            pbAdd.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void pbSub_MouseLeave(object sender, System.EventArgs e)
        {
            pbSub.BackColor = System.Drawing.Color.Transparent;
        }

        private void pbAdd_MouseLeave(object sender, System.EventArgs e)
        {
            pbAdd.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
