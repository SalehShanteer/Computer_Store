using ApiClients.ClientDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ShippingsApiClient
    {
        private readonly HttpClient _httpClient;

        public ShippingsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<ShippingDto> FindAsync(int? shippingID)
        {
            if (!shippingID.HasValue)
            {
                throw new ArgumentNullException(nameof(shippingID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{shippingID}");
            return await GenericClientMethods.SendRequestAsync<ShippingDto>(request, _httpClient);
        }

        public async Task<ShippingDto> FindByOrderAsync(int? orderID)
        {
            if (!orderID.HasValue)
            {
                throw new ArgumentNullException(nameof(orderID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindByOrder/{orderID}");
            return await GenericClientMethods.SendRequestAsync<ShippingDto>(request, _httpClient);
        }

        public async Task<ShippingDto> SaveAsync(ShippingDto shippingDto)
        {
            if (shippingDto is null)
            {
                throw new ArgumentNullException(nameof(shippingDto));
            }
            var request = new HttpRequestMessage(
                shippingDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                shippingDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(shippingDto), Encoding.UTF8, "application/json")
            };
            return await GenericClientMethods.SendRequestAsync<ShippingDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? shippingID)
        {
            if (!shippingID.HasValue)
            {
                throw new ArgumentNullException(nameof(shippingID));
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{shippingID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? shippingID)
        {
            if (!shippingID.HasValue)
            {
                throw new ArgumentNullException(nameof(shippingID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{shippingID}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<ShippingDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<ShippingDto>>(request, _httpClient);
        }

        public async Task<decimal?> GetShippingCostAsync(int? orderID)
        {
            if (!orderID.HasValue)
            {
                throw new ArgumentNullException(nameof(orderID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"GetShippingCost/{orderID}");
            return await GenericClientMethods.SendRequestAsync<decimal?>(request, _httpClient);
        }

        public async Task<DateTime?> GetEstimatedDeliveryDateAsync(int? orderID)
        {
            if (!orderID.HasValue)
            {
                throw new ArgumentNullException(nameof(orderID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"GetEstimatedDeliveryDate/{orderID}");
            return await GenericClientMethods.SendRequestAsync<DateTime?>(request, _httpClient);
        }

        public async Task<List<string>> GetAvailableCarriersAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAvailableCarriers");
            return await GenericClientMethods.SendRequestAsync<List<string>>(request, _httpClient);
        }

        public async Task<bool> ChangeShippingStatus(ShippingStatusDto shippingStatusDto)
        {
            if (shippingStatusDto is null)
            {
                throw new ArgumentNullException(nameof(shippingStatusDto));
            }
            string query = $"?OrderID={shippingStatusDto.OrderID}&Status={shippingStatusDto.Status}";
            var request = new HttpRequestMessage(HttpMethod.Put, $"ChangeStatus{query}");
            request.Content = null; // No content for PUT request

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }
    }
}