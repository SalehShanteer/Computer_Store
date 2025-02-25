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

        public string Title { get; set; }
        public int? UserID { get; set; }
        public UserDto UserInfo { get; set; }

        public UserSettingsDto(string title, int? userID)
        {
            this.Title = title;
            this.UserID = userID;
        }

        public UserSettingsDto()
        {
            this.Title = null;
            this.UserID = null;
            this.UserInfo = new UserDto();
        }

      
    }
}
