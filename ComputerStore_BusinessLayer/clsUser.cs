using ComputerStore_DataAccessLayer;
using System.Text;
using DTOs;


namespace ComputerStore_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public UserDto userDto { get {
                return new UserDto(this.ID, this.FirstName, this.LastName, this.Email
            , this.Phone, this.Password, this.Role);
            } }

        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(FirstName);
                sb.Append(" ");
                sb.Append(LastName);
                return sb.ToString();
            }
        }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public UserDto.enRole Role { get; set; }

        public clsUser()
        {
            this.ID = null;
            this.FirstName = null;
            this.LastName = null;
            this.Email = null;
            this.Phone = null;
            this.Password = null;
            this.Role = 0;

            _Mode = enMode.AddNew;
        }

        public clsUser(UserDto userDto, enMode mode)
        {
            this.ID = userDto.ID;
            this.FirstName = userDto.FirstName;
            this.LastName = userDto.LastName;
            this.Email = userDto.Email;
            this.Phone = userDto.Phone;
            this.Password = userDto.Password;
            this.Role = userDto.Role;

            _Mode = mode;
        }

        private bool _AddNewUser()
        {
            this.ID = clsUserData.AddNewUser(this.userDto);
            return this.ID is not null;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.userDto);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }

                case enMode.Update:
                    {
                        if (_UpdateUser())
                        {
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }

        public static clsUser Find(int? id)
        {
            UserDto userDto = clsUserData.GetUserByID(id);

            if (userDto is not null)
            {
                return new clsUser(userDto, enMode.Update);
            }

            return null;
        }

        public static clsUser Find(string email)
        {
            UserDto userDto = clsUserData.GetUserByEmail(email);

            if (userDto is not null)
            {
                return new clsUser(userDto, enMode.Update);
            }

            return null;
        }

        public static bool IsExistByEmail(string Email)
        {
            return clsUserData.IsUserExistByEmail(Email);
        }

        public static bool IsExistByID(int? ID)
        {
            return clsUserData.IsUserExistByID(ID);
        }

        public static bool ChangeUserPassword(string email, string newPassword)
        {
            return clsUserData.ChangeUserPassword(email, newPassword);
        }
    }
}
