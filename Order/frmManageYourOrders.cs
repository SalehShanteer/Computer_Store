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
    public partial class frmManageYourOrders : Form
    {

        private OrdersApiClient _OrderClient = new OrdersApiClient(ApiUrls.OrdersURL);
        private ShippingsApiClient _ShippingClient = new ShippingsApiClient(ApiUrls.ShippingsURL);
        private PaymentsApiClient _PaymentClient = new PaymentsApiClient(ApiUrls.PaymentsURL);

        private int _UserID;
        private int _OrderID;
        private byte _CurrentOrderStatus;

        public frmManageYourOrders(int userID)
        {
            InitializeComponent();

            _UserID = userID;
        }

        private async void frmManageYourOrders_Load(object sender, EventArgs e)
        {
            await _LoadUserOrdersAsync();
        }

        private void _DisplayOrder(OrderDto order, int positionY)
        {
            if (order == null)
            {
                return;
            }
            var orderViewer = new ctrlOrderViewer();
            orderViewer.LoadOrder(order);
            orderViewer.Location = new Point(0, positionY);
            orderViewer.Size = new Size(502, 112); // Adjust size as needed
            pnlOrders.Controls.Add(orderViewer);

            orderViewer.Click += orderViewer_Click; // Subscribe to the click event
        }

        private async Task _LoadUserOrdersAsync()
        {
            pnlOrders.Controls.Clear(); // Clear previous orders from the panel if any
            try
            {
                // Assuming you have a method to get user orders
                var orders = await _OrderClient.GetByUserAsync(_UserID);
                if (orders != null)
                {
                    int positionY = 10;
                    foreach (var order in orders)
                    {
                        // Assuming you have a method to display each order
                        _DisplayOrder(order, positionY);
                        positionY += 114; // Adjust the spacing as needed
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}");
            }
        }

        private void _DisplayShippingStatus(byte? status)
        {
            switch (status)
            {
                case 0:
                    lblShippingStatus.Text = "Cancelled";
                    lblShippingStatus.ForeColor = Color.FromArgb(245, 124, 0); // Amber
                    break;
                case 1:
                    lblShippingStatus.Text = "Pending";
                    lblShippingStatus.ForeColor = Color.FromArgb(255, 179, 0); // Gold
                    break;
                case 2:
                    lblShippingStatus.Text = "Processing";
                    lblShippingStatus.ForeColor = Color.FromArgb(25, 118, 210); // Deep Blue
                    break;
                case 3:
                    lblShippingStatus.Text = "Delivered";
                    lblShippingStatus.ForeColor = Color.FromArgb(56, 142, 60); // Forest Green
                    break;
                default:
                    lblShippingStatus.Text = "Unknown Status";
                    lblShippingStatus.ForeColor = Color.FromArgb(97, 97, 97); // Dark Gray
                    break;
            }
        }

        private async Task _DisplayShippingInfoAsync(int? orderID)
        {
            try
            {
                // Retrieve shipping information for the order
                var shippingInfo = await _ShippingClient.FindByOrderAsync(orderID);

                if (shippingInfo != null)
                {
                    // Display shipping information
                    lblCarrier.Text = shippingInfo.CarrierName;
                    lblTrackingNumber.Text = shippingInfo.TrackingNumber;
                    lblEstimatedDate.Text = clsUtility.DateTimeToString(shippingInfo.EstimatedDeliveryDate);
                    lblActualDate.Text = clsUtility.DateTimeToString(shippingInfo.ActualDeliveryDate);
                    lblShippingAddress.Text = shippingInfo.ShippingAddress;
                    _DisplayShippingStatus(shippingInfo.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shipping info: {ex.Message}");
            }
        }

        private async Task _DisplayPaymentInfoAsync(int? orderID)
        {
            try
            {
                var paymentInfo = await _PaymentClient.FindByOrderAsync(orderID);

                if (paymentInfo != null)
                {
                    // Display payment information
                    var paymentMethod = await paymentInfo.GetPaymentMethodAsync();
                    lblPaymentMethod.Text = paymentMethod.Name;
                    lblTotalPrice.Text = clsUtility.DecimalToMoneyString(paymentInfo.Amount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment info: {ex.Message}");
            }
        }

        private async Task _DisplayOverallOrderInfoAsync(int? orderID)
        {
            try
            {
              await Task.WhenAll(_DisplayShippingInfoAsync(orderID), _DisplayPaymentInfoAsync(orderID));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
        }

        private void _DefaultOrderInfo()
        {
            lblOrderID.Text = "???";
            lblCarrier.Text = "???";
            lblTrackingNumber.Text = "???";
            lblEstimatedDate.Text = "???";
            lblActualDate.Text = "???";
            lblShippingAddress.Text = "???";
            lblPaymentMethod.Text = "???";
            lblTotalPrice.Text = "???";
            lblShippingStatus.Text = "???";

            // Hide the cancel order button
            btnCancelOrder.Visible = false;
        }

        private async Task<bool> _CancelOrderAsync()
        {
            var isCanceled = await _OrderClient.UpdateStatusAsync(new OrderStatusDto(_OrderID, 0));
            return isCanceled;
        }

        private async void orderViewer_Click(object sender, EventArgs e)
        {
            // Assuming you have a method to get order details
            _DefaultOrderInfo();

            // Handle order viewer click event
            // You can show order details or perform any action you want
            var orderViewer = sender as ctrlOrderViewer;
            if (orderViewer != null)
            {
                if (orderViewer.OrderID != null)
                {
                    _OrderID = orderViewer.OrderID.Value;
                    lblOrderID.Text = _OrderID.ToString();
                    _CurrentOrderStatus = orderViewer.OrderStatus.Value;

                    if (_CurrentOrderStatus != 1)
                    {
                        if (_CurrentOrderStatus == 2 || _CurrentOrderStatus == 3)
                        {
                            btnCancelOrder.Visible = true;
                        }
                        await _DisplayOverallOrderInfoAsync(_OrderID);
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to load order details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this order with id = " + _OrderID, "Cancel the order?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                if (_CurrentOrderStatus == 2 || _CurrentOrderStatus == 3)
                {
                    if (await _CancelOrderAsync())
                    {
                        MessageBox.Show("Order canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await _LoadUserOrdersAsync();
                        await _DisplayOverallOrderInfoAsync(_OrderID);
                        btnCancelOrder.Visible = false; // Hide the cancel button after successful cancellation
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
        }
    }
}
