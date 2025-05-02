using ApiClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClients.Api_URLs;
using ApiClients.ClientDtos;

namespace Computer_Store
{
    public partial class frmPaymentPortal : Form
    {
        private ShippingsApiClient _ShippingClient = new ShippingsApiClient(ApiUrls.ShippingsURL);
        private PaymentMethodsApiClient _PaymentMethodClient = new PaymentMethodsApiClient(ApiUrls.PaymentMethodsURL);
        private PaymentsApiClient _PaymentClient = new PaymentsApiClient(ApiUrls.PaymentURL);
        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiUrls.OrdersURL);

        private int? _OrderID;
        private decimal? _TotalPrice = 0;

        public frmPaymentPortal(int? orderID)
        {
            InitializeComponent();

            _OrderID = orderID;
        }

        private async void frmPaymentPortal_Load(object sender, EventArgs e)
        {
            await _LoadPaymentPage();
        }

        private async Task _LoadPaymentMethods()
        {
            // Load payment methods from the API
            var paymentMethods = await _PaymentMethodClient.GetAllAsync();
            if (paymentMethods != null)
            {
                // Populate the payment methods into the combo box
                cbxPaymentMethods.DataSource = paymentMethods;
                cbxPaymentMethods.DisplayMember = "Name";
                cbxPaymentMethods.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show("Failed to load payment methods", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _LoadOrderPrice()
        {
            // Load order price from the API
            var order = await _OrdersClient.FindAsync(_OrderID);
            if (order != null)
            {
                lblPrice.Text = clsUtility.DecimalToMoneyString(order.TotalAmount);
 
                _TotalPrice += order.TotalAmount;
            }
            else
            {
                MessageBox.Show("Failed to load order price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _TotalPrice = null;
            }
        }

        private async Task _LoadShippingCarriesrs()
        {
            // Load shipping carriers from the API
            var shippingCarriers = await _ShippingClient.GetAvailableCarriersAsync();
            if (shippingCarriers != null)
            {
                // Populate the shipping carriers into the combo box
                foreach (var carrier in shippingCarriers)
                {
                    cbxShippingCarriers.Items.Add(carrier);
                }
                cbxShippingCarriers.SelectedIndex = 0; // Select the first item by default
            }
            else
            {
                MessageBox.Show("Failed to load shipping carriers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _LoadShippingCost()
        {
            decimal? shippingCost = 0;
            shippingCost = await _ShippingClient.GetShippingCostAsync(_OrderID);

            if (shippingCost != null)
            {
                lblShippingCost.Text = clsUtility.DecimalToMoneyString(shippingCost);

                _TotalPrice += shippingCost;
            }
            else
            {
                MessageBox.Show("Failed to load shipping cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _TotalPrice = null;
            }
        }

        private void _LoadTotalPrice()
        {
            if (_TotalPrice != null)
            {
                lblTotalPrice.Text = clsUtility.DecimalToMoneyString(_TotalPrice);
            }
            else
            {
                MessageBox.Show("Failed to load total amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task _LoadEstimatedDeliveryDate()
        {
            DateTime? estimatedDeliveryDate = null;
            estimatedDeliveryDate = await _ShippingClient.GetEstimatedDeliveryDateAsync(_OrderID);
            if (estimatedDeliveryDate != null)
            {
                lblEstimatedDeliveryDate.Text = estimatedDeliveryDate.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Failed to load estimated delivery date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _LoadPaymentPage()
        {
            if (_OrderID == null)
            {
                MessageBox.Show("Invalid Order ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            await Task.WhenAll(_LoadPaymentMethods(), _LoadShippingCarriesrs(), _LoadShippingCost(), _LoadEstimatedDeliveryDate(), _LoadOrderPrice());

            _LoadTotalPrice();
        }

        private async void _Purchase()
        {
            // Create a new payment object
            var payment = new PaymentDto
            {
                OrderID = _OrderID,
                PaymentMethodID = (int)cbxPaymentMethods.SelectedValue,
                Amount = _TotalPrice,
            };
            // Save the payment to the API
            var savedPayment = await _PaymentClient.SaveAsync(payment);
            if (savedPayment != null)
            {
                MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to process payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            _Purchase();
        }
    }
}
