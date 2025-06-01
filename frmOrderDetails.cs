using ApiClients;
using ApiClients.ClientDtos;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmOrderDetails : Form
    {

        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiClients.Api_URLs.ApiUrls.OrdersURL);
        private OrderItemsApiClient _OrderItemsClient = new OrderItemsApiClient(ApiClients.Api_URLs.ApiUrls.OrderItemsURL);

        private int _OrderID;

        public frmOrderDetails(int OrderID)
        {
            InitializeComponent();
            _OrderID = OrderID;
        }

        private async void frmOrderDetails_Load(object sender, EventArgs e)
        {
            await _LoadOrderAsync(_OrderID);
        }

        private async Task _LoadOrderAsync(int? OrderID)
        {

            OrderDto order = await _OrdersClient.FindAsync(OrderID);

            // Check if the order is not null and has a status of 1 (Draft)
            if (order != null)
            {
                await _LoadOrderItemsAsync();
            }
            else
            {
                MessageBox.Show("No order found or the order is not in draft status.", "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form if no order found
            }
        }

        private async Task _LoadOrderItemsAsync()
        {
            var orderItems = await _OrderItemsClient.GetByOrderAsync(_OrderID);
            if (orderItems != null && orderItems.Any())
            {
                int positionY = 10;
                // Load order items into the UI
                foreach (var item in orderItems)
                {
                    await _LoadOneOrderItemAsync(item, positionY);
                    positionY += 5 + 122; // Adjust the position for the next item
                }
            }
            else
            {
                MessageBox.Show("No items found in this order.", "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task _LoadOneOrderItemAsync(OrderItemDto orderItem, int positionY)
        {
            if (orderItem == null)
            {
                return;
            }
            var orderItemViewer = new ctrlOrderItemViewer();
            await orderItemViewer.LoadOrderItemAsync(orderItem
                , ctrlOrderItemViewer.enumOrderItemViewerMode.View); // Set the control to read-only mode
            orderItemViewer.Location = new Point(10, positionY);
            orderItemViewer.Size = new Size(526, 122);
            pnItemsContainer.Controls.Add(orderItemViewer);           
        }
    }
}
