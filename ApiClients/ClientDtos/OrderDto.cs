using System;

namespace ApiClients.ClientDtos
{
    public class OrderDto
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public byte? Status { get; set; } // 0 => Canceled, 1 => Draft, 2 => Pending, 3 => Processing, 4 => Delivered

        public OrderDto()
        {
            this.ID = null;
            this.UserID = null;
            this.TotalAmount = null;
            this.OrderDate = null;
            this.Status = null;
        }

        public OrderDto(int? orderId, int? userId, decimal? totalAmount, DateTime? orderDate, byte? status)
        {
            this.ID = orderId;
            this.UserID = userId;
            this.TotalAmount = totalAmount;
            this.OrderDate = orderDate;
            this.Status = status;
        }
    }
}