using ApiClients;
using ApiClients.ClientDtos;
using System.Drawing;
using System.Windows.Forms;

namespace Computer_Store
{
    public partial class ctrlOrderViewer : UserControl
    {
        public ctrlOrderViewer()
        {
            InitializeComponent();
        }

        private int? _orderID;
        private byte? _orderStatus;

        public int? OrderID
        {
            get
            {
                return _orderID;
            }
        }

        public byte? OrderStatus
        {
            get
            {
                return _orderStatus;
            }
        }

        private void _DisplayOrderStatus(byte? status)
        {
            if (status.HasValue)
            {
                switch (status.Value)
                {
                    case 0:
                        lblStatus.Text = "Canceled";
                        lblStatus.ForeColor = Color.FromArgb(211, 47, 47); // Dark Red
                        break;
                    case 1:
                        lblStatus.Text = "Draft";
                        lblStatus.ForeColor = Color.FromArgb(245, 124, 0); // Amber
                        break;
                    case 2:
                        lblStatus.Text = "Pending";
                        lblStatus.ForeColor = Color.FromArgb(255, 179, 0); // Gold
                        break;
                    case 3:
                        lblStatus.Text = "Processing";
                        lblStatus.ForeColor = Color.FromArgb(25, 118, 210); // Deep Blue
                        break;
                    case 4:
                        lblStatus.Text = "Delivered";
                        lblStatus.ForeColor = Color.FromArgb(56, 142, 60); // Forest Green
                        break;
                    default:
                        lblStatus.Text = "Unknown Status";
                        lblStatus.ForeColor = Color.FromArgb(97, 97, 97); // Dark Gray
                        break;
                }
            }
            else
            {
                lblStatus.Text = "Unknown Status";
                lblStatus.ForeColor = Color.FromArgb(97, 97, 97); // Dark Gray
            }
        }

        private void _DisplayOrderDetails(OrderDto order)
        {
            if (order != null)
            {
                _orderID = order.ID;
                _orderStatus = order.Status;
                lblOrderID.Text = order.ID.ToString();
                lblOrderDate.Text = clsUtility.DateTimeToString(order.OrderDate);
                lblTotalPrice.Text = clsUtility.DecimalToMoneyString(order.TotalAmount);
                lblUserID.Text = order.UserID.ToString();
                _DisplayOrderStatus(order.Status);
            }
            else
            {
                MessageBox.Show("Failed to load order details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadOrder(OrderDto order)
        {
            if (order != null)
            {
                _DisplayOrderDetails(order);
            }
            else
            {
                MessageBox.Show("Failed to load order details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
