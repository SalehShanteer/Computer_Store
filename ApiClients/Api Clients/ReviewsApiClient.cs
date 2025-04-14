using ApiClients.ClientDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ReviewsApiClient
    {
        private readonly HttpClient _httpClient;

        public ReviewsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<ReviewDto> FindAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid review ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<ReviewDto>(request, _httpClient);
        }

        public async Task<ReviewDto> FindAsync(int productId, int userId)
        {
            if (productId < 1 || userId < 1)
            {
                throw new ArgumentException("Invalid product or user ID", nameof(productId));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindByUserAndProduct/{productId}/{userId}");
            return await GenericClientMethods.SendRequestAsync<ReviewDto>(request, _httpClient);
        }

        public async Task<ReviewDto> SaveAsync(ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                throw new ArgumentNullException(nameof(reviewDto));
            }
            var request = new HttpRequestMessage(
                reviewDto.ID is null ? HttpMethod.Post : HttpMethod.Put
                , reviewDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(reviewDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<ReviewDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid review ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid review ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<ReviewDto>> GetByProductAsync(int? productId)
        {
            if (!productId.HasValue || productId < 1)
            {
                throw new ArgumentException("Invalid product ID", nameof(productId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"GetByProduct/{productId}");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<ReviewDto>>(request, _httpClient);
        }

        public async Task<IEnumerable<ReviewDto>> GetByUserAsync(int? userId)
        {
            if (!userId.HasValue || userId < 1)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"GetByUser/{userId}");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<ReviewDto>>(request, _httpClient);
        }

        public async Task<double?> GetAverageRatingAsync(int? productId)
        {
            if (!productId.HasValue || productId < 1)
            {
                throw new ArgumentException("Invalid product ID", nameof(productId));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"GetAverageRating/{productId}");
            return await GenericClientMethods.SendRequestAsync<double?>(request, _httpClient);
        }

        public async Task<int> GetTotalByProductAsync(int? productId)
        {
            if (!productId.HasValue || productId < 1)
            {
                throw new ArgumentException("Invalid product ID", nameof(productId));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"GetTotalByProduct/{productId}");
            return await GenericClientMethods.SendRequestAsync<int>(request, _httpClient);
        }

    }
}