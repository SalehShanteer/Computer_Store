using System;

namespace DTOs
{
    public class UserDto
    {
        public enum enRole { Customer = 0, Admin = 1 }

        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public enRole Role { get; set; }

        public UserDto() 
        {
            this.ID = null;
            this.FirstName = null;
            this.LastName = null;
            this.Email = null;
            this.Phone = null;
            this.Password = null;
            this.Role = enRole.Customer;
        }

        public UserDto(int? id, string? firstName, string? lastName, string? email, string? phone
            , string? password, enRole role)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Password = password;
            this.Role = role;
        }
    }
}
