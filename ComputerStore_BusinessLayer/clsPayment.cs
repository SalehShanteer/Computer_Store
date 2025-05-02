using DTOs;
using ComputerStore_DataAccessLayer;

namespace ComputerStore_BusinessLayer
{
    public class clsPayment
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? PaymentID { get; set; }
        public int? OrderID { get; set; }
        public decimal? Amount { get; set; }
        public int? PaymentMethodID { get; set; }
        public DateTime? TransactionDate { get; set; }

        public PaymentDto PaymentDto
        {
            get
            {
                return new PaymentDto(this.PaymentID, this.OrderID, this.Amount, this.PaymentMethodID, this.TransactionDate);
            }
        }

        public clsPayment()
        {
            this.PaymentID = null;
            this.OrderID = null;
            this.Amount = null;
            this.PaymentMethodID = null;
            this.TransactionDate = null;
            _Mode = enMode.AddNew;
        }

        public clsPayment(PaymentDto paymentDto, enMode mode)
        {
            this.PaymentID = paymentDto.ID;
            this.OrderID = paymentDto.OrderID;
            this.Amount = paymentDto.Amount;
            this.PaymentMethodID = paymentDto.PaymentMethodID;
            this.TransactionDate = paymentDto.TransactionDate;
            _Mode = mode;
        }

        private bool AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.PaymentDto);
            return this.PaymentID is not null;
        }

        private bool UpdatePayment() => clsPaymentData.UpdatePayment(this.PaymentDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewPayment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return UpdatePayment();
            }
            return false;
        }

        public static bool Delete(int paymentID) => clsPaymentData.DeletePayment(paymentID);

        public static clsPayment Find(int paymentID)
        {
            PaymentDto paymentDto = clsPaymentData.GetPaymentByID(paymentID);
            if (paymentDto is not null)
            {
                return new clsPayment(paymentDto, enMode.Update);
            }
            return null;
        }

        public static clsPayment FindByOrder(int orderID)
        {
            PaymentDto paymentDto = clsPaymentData.GetPaymentByOrderID(orderID);
            if (paymentDto is not null)
            {
                return new clsPayment(paymentDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? paymentID) => clsPaymentData.IsPaymentExistID(paymentID);

        public static List<PaymentDto> GetAllPayments() => clsPaymentData.GetAllPayments();
    }
}