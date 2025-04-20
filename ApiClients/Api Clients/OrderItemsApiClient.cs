using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiClients
{
    public class OrderItemsApiClient
    {
        private readonly HttpClient _httpClient;

        public OrderItemsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<OrderItemDto> FindAsync(int? orderId, int? productId)
        {
            if (!orderId.HasValue || !productId.HasValue)
            {
                throw new ArgumentNullException(orderId.HasValue ? nameof(productId) : nameof(orderId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{orderId}/{productId}");

            return await GenericClientMethods.SendRequestAsync<OrderItemDto>(request, _httpClient);
        }

        public async Task<OrderItemDto> SaveAsync(OrderItemDto orderItemDto)
        {
            if (orderItemDto is null)
            {
                throw new ArgumentNullException(nameof(orderItemDto));
            }

            var request = new HttpRequestMessage(
                !orderItemDto.OrderID.HasValue || !orderItemDto.ProductID.HasValue ? HttpMethod.Post : HttpMethod.Put,
                !orderItemDto.OrderID.HasValue || !orderItemDto.ProductID.HasValue ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(orderItemDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<OrderItemDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? orderId, int? productId)
        {
            if (!orderId.HasValue || !productId.HasValue)
            {
                throw new ArgumentNullException(orderId.HasValue ? nameof(productId) : nameof(orderId));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{orderId}/{productId}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? orderId, int? productId)
        {
            if (!orderId.HasValue || !productId.HasValue)
            {
                throw new ArgumentNullException(orderId.HasValue ? nameof(productId) : nameof(orderId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{orderId}/{productId}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<OrderItemDto>> GetByOrderAsync(int? orderId)
        {
            if (!orderId.HasValue)
            {
                throw new ArgumentNullException(nameof(orderId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"GetByOrder/{orderId}");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<OrderItemDto>>(request, _httpClient);
        }
    }
}