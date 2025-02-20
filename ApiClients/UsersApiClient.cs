using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiClients.ClientDtos;

namespace ApiClients
{
    public class UsersApiClient
    {
        private readonly HttpClient _httpClient;

        public UsersApiClient(string baseUrl)
        {
            _httpClient = new HttpClient{ BaseAddress = new Uri(baseUrl) };
        }

        //private async Task<T> SendRequestAsync<T>(HttpRequestMessage request, HttpClient httpClient)
        //{
        //    var response = await httpClient.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonString = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<T>(jsonString);
        //    }
        //    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        //    {
        //        throw new ArgumentException("Invalid request data");
        //    }
        //    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        throw new InvalidOperationException("Resource not found");
        //    }
        //    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        //    {
        //        throw new Exception("An error occurred on the server");
        //    }

        //    response.EnsureSuccessStatusCode();
        //    throw new Exception("Unexpected response from the server");
        //}

        public async Task<UserDto> FindAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");
            return await GenericClientMethods.SendRequestAsync<UserDto>(request, _httpClient);
        }

        public async Task<UserDto> FindAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find?email={email}");
            return await GenericClientMethods.SendRequestAsync<UserDto>(request, _httpClient);
        }

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist?email={email}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> ChangeUserPasswordAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Email and password cannot be null or empty");
            }

            var content = new { Email = email, Password = password };
            var request = new HttpRequestMessage(HttpMethod.Put, "ChangePassword")
            {
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<UserDto> Save(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var request = new HttpRequestMessage(
                userDto.ID == null ? HttpMethod.Post : HttpMethod.Put,
                userDto.ID == null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<UserDto>(request, _httpClient);
        }
    }
}