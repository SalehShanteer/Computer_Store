using ApiClients.ClientDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class PaymentsApiClient
    {
        private readonly HttpClient _httpClient;

        public PaymentsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<PaymentDto> FindAsync(int? paymentID)
        {
            if (!paymentID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{paymentID}");
            return await GenericClientMethods.SendRequestAsync<PaymentDto>(request, _httpClient);
        }

        public async Task<PaymentDto> FindByOrderAsync(int? orderID)
        {
            if (!orderID.HasValue)
            {
                throw new ArgumentNullException(nameof(orderID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindByOrder/{orderID}");
            return await GenericClientMethods.SendRequestAsync<PaymentDto>(request, _httpClient);
        }

        public async Task<PaymentDto> SaveAsync(PaymentDto paymentDto)
        {
            if (paymentDto is null)
            {
                throw new ArgumentNullException(nameof(paymentDto));
            }
            var request = new HttpRequestMessage(
                paymentDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                paymentDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(paymentDto), Encoding.UTF8, "application/json")
            };
            return await GenericClientMethods.SendRequestAsync<PaymentDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? paymentID)
        {
            if (!paymentID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentID));
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{paymentID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? paymentID)
        {
            if (!paymentID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{paymentID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<PaymentDto>>(request, _httpClient);
        }
    }
}
