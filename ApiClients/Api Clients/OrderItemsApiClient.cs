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

        private void ValidateOrderItemKey(OrderItemKeyDto orderItemKey)
        {
            if (!orderItemKey.OrderID.HasValue || !orderItemKey.ProductID.HasValue)
            {
                throw new ArgumentNullException(orderItemKey.OrderID.HasValue ? nameof(orderItemKey.ProductID) : nameof(orderItemKey.OrderID));
            }
            if (orderItemKey.OrderID <= 0 || orderItemKey.ProductID <= 0)
            {
                throw new ArgumentException("OrderID and ProductID must be positive.");
            }
        }

        public async Task<OrderItemDto> FindAsync(OrderItemKeyDto orderItemKey)
        {
            ValidateOrderItemKey(orderItemKey);

            string query = $"?OrderID={orderItemKey.OrderID}&ProductID={orderItemKey.ProductID}";
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find{query}");
            request.Content = null; // Ensure no body
           
            return await GenericClientMethods.SendRequestAsync<OrderItemDto>(request, _httpClient);
        }

        public async Task<OrderItemDto> AddNewAsync(OrderItemDto orderItemDto)
        {
            if (orderItemDto is null)
            {
                throw new ArgumentNullException(nameof(orderItemDto));
            }

            var request = new HttpRequestMessage(HttpMethod.Post,"Add")
            {
                Content = new StringContent(JsonConvert.SerializeObject(orderItemDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<OrderItemDto>(request, _httpClient);
        }

        public async Task<OrderItemDto> UpdateAsync(OrderItemDto orderItemDto)
        {
            if (orderItemDto is null)
            {
                throw new ArgumentNullException(nameof(orderItemDto));
            }

            var request = new HttpRequestMessage(HttpMethod.Put, "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(orderItemDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<OrderItemDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(OrderItemKeyDto orderItemKey)
        {
            ValidateOrderItemKey(orderItemKey);

            string query = $"?OrderID={orderItemKey.OrderID}&ProductID={orderItemKey.ProductID}";
            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete{query}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(OrderItemKeyDto orderItemKey)
        {
            ValidateOrderItemKey(orderItemKey);

            string query = $"?OrderID={orderItemKey.OrderID}&ProductID={orderItemKey.ProductID}";
            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist{query}");

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