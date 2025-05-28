using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiClients
{
    public class BrandsApiClient
    {
        private readonly HttpClient _httpClient;

        public BrandsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<BrandDto> FindAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid brand ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<BrandDto>(request, _httpClient);
        }

        public async Task<BrandDto> SaveAsync(BrandDto brandDto)
        {
            if (brandDto == null)
            {
                throw new ArgumentNullException(nameof(brandDto));
            }

            var request = new HttpRequestMessage(
                brandDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                brandDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(brandDto),
                    Encoding.UTF8,
                    "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<BrandDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid brand ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid brand ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Brand name cannot be null or empty", nameof(name));
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExistByName/{name}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<BrandDto>>(request, _httpClient);
        }

        public async Task<DataTable> GetAllAsDataTableAsync()
        {
            var brands = await GetAllAsync();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            // Add other columns as needed

            foreach (var brand in brands)
            {
                dt.Rows.Add(brand.ID, brand.Name, brand.ImagePath);
            }

            return dt;
        }
    }
}