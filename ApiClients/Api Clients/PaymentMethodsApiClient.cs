using ApiClients.ClientDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class PaymentMethodsApiClient
    {
        private readonly HttpClient _httpClient;

        public PaymentMethodsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<PaymentMethodDto> FindAsync(int? paymentMethodID)
        {
            if (!paymentMethodID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentMethodID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{paymentMethodID}");
            return await GenericClientMethods.SendRequestAsync<PaymentMethodDto>(request, _httpClient);
        }

        public async Task<PaymentMethodDto> FindByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be null or empty", nameof(name));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindByName?name={name}");
            return await GenericClientMethods.SendRequestAsync<PaymentMethodDto>(request, _httpClient);
        }

        public async Task<PaymentMethodDto> SaveAsync(PaymentMethodDto paymentMethodDto)
        {
            if (paymentMethodDto is null)
            {
                throw new ArgumentNullException(nameof(paymentMethodDto));
            }
            var request = new HttpRequestMessage(
                paymentMethodDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                paymentMethodDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(paymentMethodDto), Encoding.UTF8, "application/json")
            };
            return await GenericClientMethods.SendRequestAsync<PaymentMethodDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? paymentMethodID)
        {
            if (!paymentMethodID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentMethodID));
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{paymentMethodID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? paymentMethodID)
        {
            if (!paymentMethodID.HasValue)
            {
                throw new ArgumentNullException(nameof(paymentMethodID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{paymentMethodID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<PaymentMethodDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<PaymentMethodDto>>(request, _httpClient);
        }
    }
}