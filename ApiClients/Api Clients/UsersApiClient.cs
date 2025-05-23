﻿using System;
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

        public async Task<UserDto> FindAsync(int? id)
        {
            if (!id.HasValue)
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

            var encodedEmail = Uri.EscapeDataString(email);
            var request = new HttpRequestMessage(HttpMethod.Get, $"Find?email={encodedEmail}");
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

        public async Task<bool> ChangeUserPasswordAsync(UserChangePasswordDto changePasswordRequest)
        {
            if (string.IsNullOrWhiteSpace(changePasswordRequest.Email) || string.IsNullOrWhiteSpace(changePasswordRequest.Password))
            {
                throw new ArgumentException("Email and password cannot be null or empty");
            }

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), "ChangePassword")
            {
                Content = new StringContent(JsonConvert.SerializeObject(changePasswordRequest), Encoding.UTF8, "application/json")
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