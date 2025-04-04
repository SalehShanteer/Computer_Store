using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace ApiClients
{
    public class SubcategoriesApiClient
    {
        private readonly HttpClient _httpClient;

        public SubcategoriesApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<SubcategoryDto> FindAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid subcategory ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<SubcategoryDto>(request, _httpClient);
        }

        public async Task<SubcategoryDto> SaveAsync(SubcategoryDto subcategoryDto)
        {
            if (subcategoryDto == null)
            {
                throw new ArgumentNullException(nameof(subcategoryDto));
            }

            var request = new HttpRequestMessage(
                subcategoryDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                subcategoryDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(subcategoryDto),
                    Encoding.UTF8,
                    "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<SubcategoryDto>(request, _httpClient);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid subcategory ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistAsync(int? id)
        {
            if (!id.HasValue || id < 1)
            {
                throw new ArgumentException("Invalid subcategory ID", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{id}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsSubcategoryBelongsToCategoryAsync(int? subcategoryId, int? categoryId)
        {
            if (!subcategoryId.HasValue || subcategoryId < 1 || !categoryId.HasValue || categoryId < 1)
            {
                throw new ArgumentException("Invalid subcategory or category ID");
            }

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"IsSubcategoryBelongsToCategory?subcategoryID={subcategoryId}&categoryID={categoryId}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<SubcategoryDto>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "GetAll");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<SubcategoryDto>>(request, _httpClient);
        }

        public async Task<DataTable> GetAllAsDataTableAsync()
        {
            var subcategories = await GetAllAsync();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("CategoryID", typeof(int));
            // Add other columns as needed

            foreach (var subcategory in subcategories)
            {
                dt.Rows.Add(
                    subcategory.ID,
                    subcategory.Name,
                    subcategory.CategoryID);
            }

            return dt;
        }

        public async Task<IEnumerable<SubcategoryDto>> GetSubcategoriesByCategoryID(int? categoryID)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"GetSubcategoriesByCategoryID/{categoryID}");
            return await GenericClientMethods.SendRequestAsync<IEnumerable<SubcategoryDto>>(request, _httpClient);
        }

        public async Task<IEnumerable<SubcategoryDto>> GetByCategoryAsync(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId < 1)
            {
                throw new ArgumentException("Invalid category ID", nameof(categoryId));
            }

            var allSubcategories = await GetAllAsync();
            return allSubcategories.Where(s => s.CategoryID == categoryId);
        }


    }
}