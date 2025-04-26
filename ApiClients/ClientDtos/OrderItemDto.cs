using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class OrderItemDto
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public short? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalItemsPrice { get; set; } // Computed column, included for completeness

        public int? UserID { get; set; } // Optional, not used in the original code
                                         // (for create new order if item added using userid)

        public OrderItemDto()
        {
            this.OrderID = null;
            this.ProductID = null;
            this.Quantity = null;
            this.Price = null;
            this.TotalItemsPrice = null;
            UserID = null;
        }

        public OrderItemDto(int? orderId, int? productId, short? quantity, decimal? price, decimal? totalItemsPrice, int? userId)
        {
            this.OrderID = orderId;
            this.ProductID = productId;
            this.Quantity = quantity;
            this.Price = price;
            this.TotalItemsPrice = totalItemsPrice;
            UserID = userId;
        }
    }
}
