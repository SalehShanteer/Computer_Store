using System;
using System.Threading.Tasks;
using ApiClients;
using ApiClients.Api_URLs;

namespace ApiClients.ClientDtos
{
    public class PaymentDto
    {
        PaymentMethodsApiClient _PaymentMethodsClient = new PaymentMethodsApiClient(ApiUrls.PaymentMethodsURL);

        public int? ID { get; set; }
        public int? OrderID { get; set; } 
        public decimal? Amount { get; set; } 
        public int? PaymentMethodID { get; set; } 
        public DateTime? TransactionDate { get; set; }
        
        public PaymentDto()
        {
            this.ID = null;
            this.OrderID = null;
            this.Amount = null;
            this.PaymentMethodID = null;
            this.TransactionDate = null;
        }

        public PaymentDto(int? id, int? orderID, decimal? amount, int? paymentMethodID, DateTime? transactionDate)
        {
            this.ID = id;
            this.OrderID = orderID;
            this.Amount = amount;
            this.PaymentMethodID = paymentMethodID;
            this.TransactionDate = transactionDate;
        }

        public async Task<PaymentMethodDto> GetPaymentMethodAsync()
        {
            if (PaymentMethodID.HasValue)
            {
                return await _PaymentMethodsClient.FindAsync(PaymentMethodID.Value);
            }
            return null;
        }


    }
}