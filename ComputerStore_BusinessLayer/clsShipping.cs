using DTOs;
using ComputerStore_DataAccessLayer;
using System.Reflection.Metadata.Ecma335;

namespace ComputerStore_BusinessLayer
{
    public class clsShipping
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ShippingID { get; set; }
        public int? OrderID { get; set; }
        public string? CarrierName { get; set; }
        public string? TrackingNumber { get; set; }
        public decimal? ShippingCost { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public byte? Status { get; set; }

        public ShippingDto ShippingDto
        {
            get
            {
                return new ShippingDto(this.ShippingID, this.OrderID, this.CarrierName, this.TrackingNumber,
                                       this.ShippingCost, this.ShippingAddress, this.EstimatedDeliveryDate,
                                       this.ActualDeliveryDate, this.Status);
            }
        }

        public clsShipping()
        {
            this.ShippingID = null;
            this.OrderID = null;
            this.CarrierName = null;
            this.TrackingNumber = null;
            this.ShippingCost = null;
            this.ShippingAddress = null;
            this.EstimatedDeliveryDate = null;
            this.ActualDeliveryDate = null;
            this.Status = null;
            _Mode = enMode.AddNew;
        }

        public clsShipping(ShippingDto shippingDto, enMode mode)
        {
            this.ShippingID = shippingDto.ID;
            this.OrderID = shippingDto.OrderID;
            this.CarrierName = shippingDto.CarrierName;
            this.TrackingNumber = shippingDto.TrackingNumber;
            this.ShippingCost = shippingDto.ShippingCost;
            this.ShippingAddress = shippingDto.ShippingAddress;
            this.EstimatedDeliveryDate = shippingDto.EstimatedDeliveryDate;
            this.ActualDeliveryDate = shippingDto.ActualDeliveryDate;
            this.Status = shippingDto.Status;
            _Mode = mode;
        }

        private bool AddNewShipping()
        {
            this.ShippingID = clsShippingData.AddNewShipping(this.ShippingDto);
            return this.ShippingID is not null;
        }

        private bool UpdateShipping() => clsShippingData.UpdateShipping(this.ShippingDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewShipping())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return UpdateShipping();
            }
            return false;
        }

        public static bool Delete(int shippingID) => clsShippingData.DeleteShipping(shippingID);

        public static clsShipping Find(int shippingID)
        {
            ShippingDto shippingDto = clsShippingData.GetShippingByID(shippingID);
            if (shippingDto is not null)
            {
                return new clsShipping(shippingDto, enMode.Update);
            }
            return null;
        }

        public static clsShipping FindByOrder(int orderID)
        {
            ShippingDto shippingDto = clsShippingData.GetShippingByOrderID(orderID);
            if (shippingDto is not null)
            {
                return new clsShipping(shippingDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? shippingID) => clsShippingData.IsShippingExistID(shippingID);

        public static List<ShippingDto> GetAllShippings() => clsShippingData.GetAllShippings();

        public static decimal? GetShippingCost(int? orderID) => clsShippingData.GetShippingCost(orderID);

        public static DateTime? GetEstimatedDeliveryDate(int? orderID) => clsShippingData.GetEstimatedDeliveryDate(orderID);

        public static List<string> GetAvailableCarriers() => clsShippingData.GetAvailableCarriers();
    }
}