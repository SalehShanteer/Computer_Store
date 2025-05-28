using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiClients
{
    public class OrdersApiClient
    {
        private readonly HttpClient _httpClient;

        public OrdersApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<OrderDto> FindAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");

            return await GenericClientMethods.SendRequestAsync<OrderDto>(request, _httpClient);
        }

        public async Task<OrderDto> FindCurrentAsync(int? userID)
        {
            if (!userID.HasValue)
            {
                throw new ArgumentNullException(nameof(userID));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindCurrent/{userID}");
            return await GenericClientMethods.SendRequestAsync<OrderDto>(request, _httpClient);
        }

        public async Task<OrderDto> SaveAsync(OrderDto orderDto)
        {
            if (orderDto is null)
            {
                throw new ArgumentNullException(nameof(orderDto));
            }

            var request = new HttpRequestMessage(
                orderDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                orderDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<OrderDto>(request, _httpClient);
        }

        public async Task<bool> UpdateStatusAsync(OrderStatusDto orderStatus)
        {
            if (orderStatus is null)
            {
                throw new ArgumentNullException(nameof(orderStatus));
            }

            string query = $"?ID={orderStatus.ID}&Status={orderStatus.Status}";
            var request = new HttpRequestMessage(HttpMethod.Put, $"UpdateStatus{query}");
            request.Content = null; // Ensure no body

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{id}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<OrderDto>>(request, _httpClient);
        }

        public async Task<IEnumerable<OrderDto>> GetByUserAsync(int? userId)
        {
            if (!userId.HasValue)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"GetByUser/{userId}");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<OrderDto>>(request, _httpClient);
        }
    }
}