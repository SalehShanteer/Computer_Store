using System;

namespace DTOs
{
    public class OrderDetailsDto
    {
        public int? OrderID { get; set; }
        public int? UserID { get; set; }
        public decimal? OrderCost { get; set; }
        public decimal? ShippingCost { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string ShippingStatus { get; set; }

        public OrderDetailsDto()
        {
            OrderID = null;
            UserID = null;
            OrderCost = null;
            ShippingCost = null;
            TotalCost = null;
            OrderDate = null;
            OrderStatus = null;
            ShippingAddress = null;
            TrackingNumber = null;
            EstimatedDeliveryDate = null;
            ActualDeliveryDate = null;
            ShippingStatus = null;
        }

        public OrderDetailsDto(
            int? orderID,
            int? userID,
            decimal? orderCost,
            decimal? shippingCost,
            decimal? totalCost,
            DateTime? orderDate,
            string orderStatus,
            string shippingAddress,
            string trackingNumber,
            DateTime? estimatedDeliveryDate,
            DateTime? actualDeliveryDate,
            string shippingStatus)
        {
            OrderID = orderID;
            UserID = userID;
            OrderCost = orderCost;
            ShippingCost = shippingCost;
            TotalCost = totalCost;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            ShippingAddress = shippingAddress;
            TrackingNumber = trackingNumber;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            ActualDeliveryDate = actualDeliveryDate;
            ShippingStatus = shippingStatus;
        }
    }
}