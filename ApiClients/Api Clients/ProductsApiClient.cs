using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ProductsApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<ProductDto> FindAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");

            return await GenericClientMethods.SendRequestAsync<ProductDto>(request, _httpClient);
        }

        public async Task<ProductDetailsDto> FindWithDetailsAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindWithDetails/{id}");
            return await GenericClientMethods.SendRequestAsync<ProductDetailsDto>(request, _httpClient);
        }

        public async Task<ProductDto> FindAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be null or empty", nameof(name));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find?name={name}");

            return await GenericClientMethods.SendRequestAsync<ProductDto>(request, _httpClient);
        }

        public async Task<ProductDto> SaveAsync(ProductDto productDto)
        {
            if (productDto is null)
            {
                throw new ArgumentNullException(nameof(productDto));
            }

            var request = new HttpRequestMessage(
                productDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                productDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<ProductDto>(request, _httpClient);
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

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<ProductDto>>(request, _httpClient);
        }

        public async Task<IEnumerable<ProductDto>> GetAllFilteredAsync(ProductFilterDto filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "GetAllFiltered")
            {
                Content = new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<IEnumerable<ProductDto>>(request, _httpClient);
        }

        public async Task<IEnumerable<ProductDetailsDto>> GetAllDetailsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAllDetails");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<ProductDetailsDto>>(request, _httpClient);
        }

    }
}
