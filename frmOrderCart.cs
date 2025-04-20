using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmOrderCart : Form
    {
        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiUrls.OrdersURL);
        private OrderItemsApiClient _OrderItemsClient = new OrderItemsApiClient(ApiUrls.OrderItemsURL);

        private OrderDto _Order;

        public frmOrderCart(int? UserID)
        {
            InitializeComponent();
            LoadOrderAsync(UserID);
        }

        private void _HideNoCart()
        {
            lblEmptyCart.Visible = false;
            pbEmptyCart.Visible = false;
        }

        private async void LoadOrderAsync(int? UserID)
        {
            _Order = await _OrdersClient.FindCurrentAsync(UserID);
            
            if (_Order != null)
            {
                await _LoadOrderItems();
            }
        }

        private async Task _LoadOneOrderItem(OrderItemDto orderItem, int positionY)
        {
            if (orderItem == null)
            {
                return;
            }
            var orderItemViewer = new ctrlOrderItemViewer();
            await orderItemViewer.LoadOrderItem(orderItem);
            orderItemViewer.Location = new Point(10, positionY);
            orderItemViewer.Size = new Size(526, 122);
            pnItemsContainer.Controls.Add(orderItemViewer);
        }

        private async Task _LoadOrderItems()
        {
            if (_Order == null)
            {
                return;
            }
            var orderItems = await _OrderItemsClient.GetByOrderAsync(_Order.OrderID);
            if (orderItems != null && orderItems.Any())
            {
                int positionY = 10;
                // Load order items into the UI
                foreach (var item in orderItems)
                {
                    await _LoadOneOrderItem(item, positionY);
                    positionY += 5 + 122; // Adjust the position for the next item
                }
            }
            else
            {
                // No items in the order
                lblEmptyCart.Visible = true;
                pbEmptyCart.Visible = true;
            }
        }

    }
}
