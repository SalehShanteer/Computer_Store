using System;

namespace DTOs
{
    public class ShippingDto
    {
        public int? ID { get; set; }
        public int? OrderID { get; set; }
        public string? CarrierName { get; set; }
        public string? TrackingNumber { get; set; } // Computed in DB
        public decimal? ShippingCost { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public byte? Status { get; set; } // 0 => canceled, 1 => pending, 2 => processing, 3 => delivered

        public ShippingDto()
        {
            this.ID = null;
            this.OrderID = null;
            this.CarrierName = null;
            this.TrackingNumber = null;
            this.ShippingCost = null;
            this.ShippingAddress = null;
            this.EstimatedDeliveryDate = null;
            this.ActualDeliveryDate = null;
            this.Status = null;
        }

        public ShippingDto(int? id, int? orderID, string? carrierName, string? trackingNumber,
                           decimal? shippingCost, string? shippingAddress, DateTime? estimatedDeliveryDate,
                           DateTime? actualDeliveryDate, byte? status)
        {
            this.ID = id;
            this.OrderID = orderID;
            this.CarrierName = carrierName;
            this.TrackingNumber = trackingNumber;
            this.ShippingCost = shippingCost;
            this.ShippingAddress = shippingAddress;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.ActualDeliveryDate = actualDeliveryDate;
            this.Status = status;
        }
    }
}