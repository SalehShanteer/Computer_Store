using ApiClients.Api_URLs;
using ApiClients;
using ApiClients.ClientDtos;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlOrderItemViewer : UserControl
    {

      
        public class OrderItemInfo
        {
            public int? ProductID { get; set; }
            public short? Quantity { get; set; }

            public OrderItemInfo(int? productID, short? quantity)
            {
                ProductID = productID;
                Quantity = quantity;
            }
        }

        // Delegates and events for notifying changes in order item
        public delegate void OrderItemDeletedHandler(object sender, bool isDeleted);
        public event OrderItemDeletedHandler OrderItemDeleted;

        public delegate void OrderItemQuantityChangedHandler(object sender, OrderItemInfo orderItemInfo);
        public event OrderItemQuantityChangedHandler OrderItemQuantityChanged;


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

        public short? SelectedQuantity
        {
            get
            {
                return _SelectedQuantity;
            }
        }

        public decimal? Price
        {
            get
            {
                if (_OrderItem == null)
                {
                    return null;
                }
                return _OrderItem.Price;
            }
        }

        public ctrlOrderItemViewer()
        {
            InitializeComponent();
        }

        public async Task LoadOrderItemAsync(OrderItemDto orderItem)
        {
            if (orderItem is null)
            {
                MessageBox.Show("The order item is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _OrderItem = orderItem;

            await _DisplayOrderItemAsync();
        }

        private async Task _DisplayOrderItemImageAsync()
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

        private async Task _DisplayOrderItemAsync()
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

            if (_SelectedQuantity > _ProductQuantity)
            {
                // If the selected quantity is greater than the available quantity, set it to the maximum available
                _SelectedQuantity = _ProductQuantity;

                if (_ProductQuantity == 0)
                {
                    // If the product is out of stock, delete the item and set the background color to red
                    await _OrderItemClient.DeleteAsync(new OrderItemKeyDto(_OrderItem.OrderID, _OrderItem.ProductID));
                    this.BackColor = System.Drawing.Color.LightCoral;
                    lblQuantity.Text = "0";
                }
            }

            await _DisplayOrderItemImageAsync();
        }

        private async void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to remove this item from the order?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var isDeleted = await _OrderItemClient.DeleteAsync(new OrderItemKeyDto(_OrderItem.OrderID, _OrderItem.ProductID));

                if (isDeleted)
                {
                    MessageBox.Show("Item removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Invoke the event to notify that the order item has been deleted
                    OrderItemDeleted?.Invoke(this, true);
                }
                else
                {
                    MessageBox.Show("Failed to remove item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                // Invoke the event to notify that the order item quantity has changed
                OrderItemQuantityChanged?.Invoke(this, new OrderItemInfo(_OrderItem.ProductID.Value, _SelectedQuantity.Value));
            }
        }

        private void pbSub_Click(object sender, System.EventArgs e)
        {
            if (_SelectedQuantity > 1)
            {
                _SelectedQuantity--;
                _UpdateOrderItemUI();

                // Invoke the event to notify that the order item quantity has changed
                OrderItemQuantityChanged?.Invoke(this, new OrderItemInfo(_OrderItem.ProductID.Value, _SelectedQuantity.Value));
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
