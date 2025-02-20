using ApiClients.Api_URLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class UserSettingsDto
    {

        private static readonly UsersApiClient _usersApiClient = new UsersApiClient(ApiUrls.UsersURL);

        public string Title { get; set; }
        public int? UserID { get; set; }
        public UserDto User { get; set; }

        public UserSettingsDto(string title, int? userID)
        {
            this.Title = title;
            this.UserID = userID;
            _InitializeUserAsync().Wait();
        }

        public UserSettingsDto()
        {
            this.Title = null;
            this.UserID = null;
            this.User = null;
        }

        private async Task _InitializeUserAsync()
        {
            if (this.UserID != null)
            {
                this.User = await _usersApiClient.FindAsync(this.UserID);
            }
        }

    }
}
