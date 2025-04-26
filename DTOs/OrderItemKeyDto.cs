using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderItemKeyDto
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }

        public OrderItemKeyDto()
        {
            this.OrderID = null;
            this.ProductID = null;
        }

        public OrderItemKeyDto(int? orderId, int? productId)
        {
            this.OrderID = orderId;
            this.ProductID = productId;
        }
    }
}
