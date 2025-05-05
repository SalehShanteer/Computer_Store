using ApiClients;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;
using Computer_Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Computer_Store.ctrlOrderItemViewer;

namespace Computer_Store
{
    public partial class frmOrderCart : Form
    {
        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiUrls.OrdersURL);
        private OrderItemsApiClient _OrderItemsClient = new OrderItemsApiClient(ApiUrls.OrderItemsURL);

        private OrderDto _Order;
        private int? _UserID;
        private Dictionary<int, short> _OrderItemsInfo = new Dictionary<int, short>();

        public frmOrderCart(int? UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmOrderCart_Load(object sender, EventArgs e)
        {
            _LoadOrderAsync(_UserID);
        }

        private void _HideNoCart()
        {
            lblEmptyCart.Visible = false;
            pbEmptyCart.Visible = false;
        }

        private void _ShowNoCart()
        {
            lblEmptyCart.Visible = true;
            pbEmptyCart.Visible = true;
        }

        private void _GetTotalPrice()
        {
            decimal totalPrice = 0;
            decimal totalItemsPrice = 0;
            foreach (Control control in pnItemsContainer.Controls)
            {
                if (control is ctrlOrderItemViewer orderItemViewer)
                {
                    totalItemsPrice = orderItemViewer.SelectedQuantity * orderItemViewer.Price ?? 0;
                    totalPrice += totalItemsPrice;
                }
            }
            lblTotalPrice.Text = clsUtility.DecimalToMoneyString(totalPrice);
        }

        private async void _LoadOrderAsync(int? UserID)
        {

            _DisableContinueToPaymentButton();

            _Order = await _OrdersClient.FindCurrentAsync(UserID);

            // Check if the order is not null and has a status of 1 (Draft)
            if (_Order != null && _Order.Status == 1)
            {
                await _LoadOrderItems();
            }
            else
            {
                // No order found for the user
                _ShowNoCart();
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

            // Subscribe to the OrderItemDeleted event
            orderItemViewer.OrderItemDeleted += ctrlOrderItem_Delete;

            // Subscribe to the orderItemQuantityChanged event
            orderItemViewer.OrderItemQuantityChanged += ctrlOrderItem_QuantityChanged;
        }

                private async Task _LoadOrderItems()
        {
            if (_Order == null)
            {
                return;
            }
            var orderItems = await _OrderItemsClient.GetByOrderAsync(_Order.ID);
            if (orderItems != null && orderItems.Any())
            {
                int positionY = 10;
                // Load order items into the UI
                foreach (var item in orderItems)
                {
                    await _LoadOneOrderItem(item, positionY);
                    positionY += 5 + 122; // Adjust the position for the next item
                }
                _HideNoCart();

                _EnableContinueToPaymentButton();
            }
            else
            {
                // No items in the order
                _ShowNoCart();
            }
            _GetTotalPrice();
        }


        private void _EnableContinueToPaymentButton()
        {
            btnContinueToPayment.Enabled = true;
            btnContinueToPayment.BackColor = Color.Black;
            btnContinueToPayment.ForeColor = Color.White;
        }

        private void _DisableContinueToPaymentButton()
        {
            btnContinueToPayment.Enabled = false;
            btnContinueToPayment.BackColor = Color.Gray;
            btnContinueToPayment.ForeColor = Color.Black;
        }

        private async void ctrlOrderItem_Delete(object sender, bool isDeleted)
        {
            if(isDeleted)
            {
                _DisableContinueToPaymentButton();

                pnItemsContainer.Controls.Clear();

                await _LoadOrderItems();
            }
        }

        private void _AddOrderItemUpdatedToUpdateList(OrderItemInfo orderItemInfo)
        {
            _OrderItemsInfo[orderItemInfo.ProductID.Value] = orderItemInfo.Quantity.Value;
        }

        private void ctrlOrderItem_QuantityChanged(object sender, OrderItemInfo orderItemInfo) 
        {
            if (orderItemInfo.ProductID != null && orderItemInfo.ProductID > 0 
                && orderItemInfo.Quantity != null && orderItemInfo.Quantity > 0)
            {
                _AddOrderItemUpdatedToUpdateList(orderItemInfo);
                _GetTotalPrice();
            }
        }

        private void _ShowPaymentPortal()
        {
            if (_Order != null)
            {
                var paymentPortal = new frmPaymentPortal(_Order.ID);
                paymentPortal.Show();
            }
            else
            {
                MessageBox.Show("No order found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _UpdateOneOrderItem(int productId, short quantity)
        {
            OrderItemDto orderItemDto = new OrderItemDto()
            {
                OrderID = _Order.ID,
                Quantity = quantity,
                ProductID = productId
            };

            orderItemDto = await _OrderItemsClient.UpdateAsync(orderItemDto);
        }

        private async Task _UpdateOrderItemsQuantityIfChanged()
        {
            // Check if there are any items to update using multiple threads
            var tasks = new List<Task>();
            Parallel.ForEach(_OrderItemsInfo.Keys, (productId) =>
            {
                if (_OrderItemsInfo[productId] > 0)
                {
                    tasks.Add(Task.Run(() => _UpdateOneOrderItem(productId, _OrderItemsInfo[productId])));
                }
            });

            await Task.WhenAll(tasks);
        }
            
        private void _ShowManageYourOrdersScreen()
        {
            frmManageYourOrders frm = new frmManageYourOrders(_UserID.Value);
            frm.Show();
        }

        private async void btnContinueToPayment_Click(object sender, EventArgs e)
        {
            await _UpdateOrderItemsQuantityIfChanged();
            _ShowPaymentPortal();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManageYourOrders_Click(object sender, EventArgs e)
        {
            _ShowManageYourOrdersScreen();
        }
    }
}
