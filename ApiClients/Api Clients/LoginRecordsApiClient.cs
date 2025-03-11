using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using ApiClients.ClientDtos;

namespace ApiClients
{
    public class LoginRecordsApiClient
    {
        private readonly HttpClient _httpClient;

        public LoginRecordsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<LoginRecordDto> FindLoginRecordByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<LoginRecordDto>(request, _httpClient);
        }

        public async Task<LoginRecordDto> AddNewLoginRecordAsync(LoginRecordDto loginRecordDto)
        {
            if (loginRecordDto == null)
            {
                throw new ArgumentNullException(nameof(loginRecordDto));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "Add")
            {
                Content = new StringContent(JsonConvert.SerializeObject(loginRecordDto), Encoding.UTF8, "application/json")
            };

            var result = await GenericClientMethods.SendRequestAsync<LoginRecordDto>(request, _httpClient);
            return result;
        }

        public async Task<DataTable> GetLoginRecordsListAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "RecordList");
            return await GenericClientMethods.SendRequestAsync<DataTable>(request, _httpClient);
        }

        public async Task<int?> GetLoginRecordsCountAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "Count");
            return await GenericClientMethods.SendRequestAsync<int?>(request, _httpClient);
        }
    }
}
