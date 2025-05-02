using DTOs;
using ComputerStore_DataAccessLayer;

namespace ComputerStore_BusinessLayer
{
    public class clsPaymentMethod
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? PaymentMethodID { get; set; }
        public string? Name { get; set; }

        public PaymentMethodDto PaymentMethodDto
        {
            get
            {
                return new PaymentMethodDto(this.PaymentMethodID, this.Name);
            }
        }

        public clsPaymentMethod()
        {
            this.PaymentMethodID = null;
            this.Name = null;
            _Mode = enMode.AddNew;
        }

        public clsPaymentMethod(PaymentMethodDto paymentMethodDto, enMode mode)
        {
            this.PaymentMethodID = paymentMethodDto.ID;
            this.Name = paymentMethodDto.Name;
            _Mode = mode;
        }

        private bool AddNewPaymentMethod()
        {
            this.PaymentMethodID = clsPaymentMethodData.AddNewPaymentMethod(this.PaymentMethodDto);
            return this.PaymentMethodID is not null;
        }

        private bool UpdatePaymentMethod() => clsPaymentMethodData.UpdatePaymentMethod(this.PaymentMethodDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewPaymentMethod())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return UpdatePaymentMethod();
            }
            return false;
        }

        public static bool Delete(int paymentMethodID) => clsPaymentMethodData.DeletePaymentMethod(paymentMethodID);

        public static clsPaymentMethod Find(int paymentMethodID)
        {
            PaymentMethodDto paymentMethodDto = clsPaymentMethodData.GetPaymentMethodByID(paymentMethodID);
            if (paymentMethodDto is not null)
            {
                return new clsPaymentMethod(paymentMethodDto, enMode.Update);
            }
            return null;
        }

        public static clsPaymentMethod FindByName(string name)
        {
            PaymentMethodDto paymentMethodDto = clsPaymentMethodData.GetPaymentMethodByName(name);
            if (paymentMethodDto is not null)
            {
                return new clsPaymentMethod(paymentMethodDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? paymentMethodID) => clsPaymentMethodData.IsPaymentMethodExistID(paymentMethodID);

        public static List<PaymentMethodDto> GetAllPaymentMethods() => clsPaymentMethodData.GetAllPaymentMethods();
    }
}