using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class UserChangePasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserChangePasswordDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
