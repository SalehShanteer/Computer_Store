using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiClients.ClientDtos;

namespace ApiClients
{
    public class UserSettingsApiClient
    {
        private readonly HttpClient _httpClient;

        public UserSettingsApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<UserSettingsDto> FindAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{title}");
            return await GenericClientMethods.SendRequestAsync<UserSettingsDto>(request, _httpClient);
        }

        public async Task<UserSettingsDto> UpdateUserSettingAsync(UserSettingsDto userSettingsDto)
        {
            if (userSettingsDto == null)
            {
                throw new ArgumentNullException(nameof(userSettingsDto));
            }

            var request = new HttpRequestMessage(HttpMethod.Put, "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(userSettingsDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<UserSettingsDto>(request, _httpClient);
        }
    }
}