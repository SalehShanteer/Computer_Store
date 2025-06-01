using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ShippingStatusDto
    { 
        public int? OrderID { get; set; }
        public byte ? Status { get; set; } // 0 => Canceled, 1 => Pending, 2 => Processing, 3 => Delivered

        public ShippingStatusDto()
        {
            this.OrderID = null;
            this.Status = null;
        }
        public ShippingStatusDto(int? orderId, byte? status)
        {
            this.OrderID = orderId;
            this.Status = status;
        }
    }
}
