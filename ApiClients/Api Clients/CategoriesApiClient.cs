using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace ApiClients
{
    public class CategoriesApiClient
    {
        private readonly HttpClient _httpClient;

        public CategoriesApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<CategoryDto> FindAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<CategoryDto>(request, _httpClient);
        }

        public async Task<CategoryDto> SaveAsync(CategoryDto categoryDto)
        {
            if (categoryDto is null)
            {
                throw new ArgumentNullException(nameof(categoryDto));
            }

            var request = new HttpRequestMessage(
                categoryDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                categoryDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(categoryDto),
                Encoding.UTF8,
                "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<CategoryDto>(request, _httpClient);
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

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<CategoryDto>>(request, _httpClient);
        }

        public async Task<DataTable> GetAllAsDataTableAsync()
        {
            var categories = await GetAllAsync();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            // Add other columns as needed

            foreach (var category in categories)
            {
                dt.Rows.Add(category.ID, category.Name);
            }

            return dt;
        }
    }
}