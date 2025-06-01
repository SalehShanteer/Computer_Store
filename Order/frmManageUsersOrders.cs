using ApiClients;
using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class frmManageUsersOrders : Form
    {

        private DataTable _dtOrdersList;

        private OrdersApiClient _OrdersClient = new OrdersApiClient(ApiClients.Api_URLs.ApiUrls.OrdersURL);
        private ShippingsApiClient _ShippingsClient = new ShippingsApiClient(ApiClients.Api_URLs.ApiUrls.ShippingsURL);
        public frmManageUsersOrders()
        {
            InitializeComponent();
        }

        private async void frmManageUsersOrders_Load(object sender, EventArgs e)
        {
            await _LoadOrdersDataTableAsync();
        }

        private async Task _LoadOrdersDataTableAsync()
        {
            _dtOrdersList = new DataTable();
            _dtOrdersList.Columns.Add("Order ID", typeof(int));
            _dtOrdersList.Columns.Add("User ID", typeof(int));
            _dtOrdersList.Columns.Add("Order Cost", typeof(string));
            _dtOrdersList.Columns.Add("Shipping Cost", typeof(string));
            _dtOrdersList.Columns.Add("Total Cost", typeof(string));
            _dtOrdersList.Columns.Add("Order Date", typeof(string));
            _dtOrdersList.Columns.Add("Order Status", typeof(string));
            _dtOrdersList.Columns.Add("Shipping Address", typeof(string));
            _dtOrdersList.Columns.Add("Tracking Number", typeof(string));
            _dtOrdersList.Columns.Add("Estimated Delivery Date", typeof(string));
            _dtOrdersList.Columns.Add("Actual Delivery Date", typeof(string));
            _dtOrdersList.Columns.Add("Shipping Status", typeof(string));

            // Corrected the type casting issue
            List<OrderDetailsDto> orders = (List<OrderDetailsDto>)await _OrdersClient.GetAllDetailsAsync();

            foreach (var order in orders)
            {

                string orderCost = order.OrderCost.HasValue ? order.OrderCost.Value.ToString("C") : "N/A";
                string shippingCost = order.ShippingCost.HasValue ? order.ShippingCost.Value.ToString("C") : "N/A";
                string totalCost = order.TotalCost.HasValue ? order.TotalCost.Value.ToString("C") : "N/A";
                string orderDate = order.OrderDate.HasValue ? order.OrderDate.Value.ToString("g") : "N/A";
                string estimatedDeliveryDate = order.EstimatedDeliveryDate.HasValue ? order.EstimatedDeliveryDate.Value.ToString("g") : "N/A";
                string actualDeliveryDate = order.ActualDeliveryDate.HasValue ? order.ActualDeliveryDate.Value.ToString("g") : "N/A";

                _dtOrdersList.Rows.Add(
                    order.OrderID,
                    order.UserID,
                    orderCost,
                    shippingCost,
                    totalCost,
                    orderDate,
                    order.OrderStatus,
                    order.ShippingAddress,
                    order.TrackingNumber,
                    estimatedDeliveryDate,
                    actualDeliveryDate,
                    order.ShippingStatus
                );
            }
            // Bind the DataTable to the DataGridView
            dgvOrdersList.DataSource = _dtOrdersList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void showOrderItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowOrderItemsScreen();
        }

        private void _ShowOrderItemsScreen()
        {

            if (dgvOrdersList.SelectedCells.Count > 0)
            {
                int orderID = Convert.ToInt32(dgvOrdersList.CurrentRow.Cells["Order ID"].Value);

                frmOrderDetails frm = new frmOrderDetails(orderID);

                frm.FormClosed += (s, e) =>
                {
                    this.Focus(); // Focus on close           
                };
                frm.Show(); // Non-blocking
            }
        }

        private async Task _StartShipping()
        {
            if (dgvOrdersList.SelectedCells.Count > 0)
            {
                int orderID = Convert.ToInt32(dgvOrdersList.CurrentRow.Cells["Order ID"].Value);

                var isShippingStart =  await _ShippingsClient.ChangeShippingStatus(new ShippingStatusDto(orderID, 2));

                if (isShippingStart)
                {
                    MessageBox.Show("Shipping started successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadOrdersDataTableAsync(); // Refresh the orders list
                }
                else
                {
                    MessageBox.Show("Failed to start shipping. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private async Task _CancelShipping()
        {
            if (dgvOrdersList.SelectedCells.Count > 0)
            {
                int orderID = Convert.ToInt32(dgvOrdersList.CurrentRow.Cells["Order ID"].Value);
                var isShippingCancelled = await _ShippingsClient.ChangeShippingStatus(new ShippingStatusDto(orderID, 0));
                if (isShippingCancelled)
                {
                    MessageBox.Show("Shipping cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadOrdersDataTableAsync(); // Refresh the orders list
                }
                else
                {
                    MessageBox.Show("Failed to cancel shipping. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task _SetShippingAsDelivered()
        {
            if (dgvOrdersList.SelectedCells.Count > 0)
            {
                int orderID = Convert.ToInt32(dgvOrdersList.CurrentRow.Cells["Order ID"].Value);
                var isShippingDelivered = await _ShippingsClient.ChangeShippingStatus(new ShippingStatusDto(orderID, 3));
                if (isShippingDelivered)
                {
                    MessageBox.Show("Shipping marked as delivered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadOrdersDataTableAsync(); // Refresh the orders list
                }
                else
                {
                    MessageBox.Show("Failed to mark shipping as delivered. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void startShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _StartShipping();
        }

        private void cmsManageProducts_Opening(object sender, CancelEventArgs e)
        {
            if (dgvOrdersList.SelectedCells.Count > 0)
            {
                string orderStatus = dgvOrdersList.CurrentRow.Cells["Order Status"].Value.ToString();

                // Enable or disable menu items based on the order status
                showOrderItemsToolStripMenuItem.Enabled = true; // Always enabled
                startShippingToolStripMenuItem.Enabled = orderStatus == "Pending";
                setShippingAsDeliveredToolStripMenuItem.Enabled = orderStatus == "Processing";
                cancelShippingToolStripMenuItem.Enabled = orderStatus == "Pending" || orderStatus == "Processing";
            }
        }

        private async void setShippingAsDeliveredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _SetShippingAsDelivered();
        }

        private async void cancelShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _CancelShipping();
        }
    }
}
