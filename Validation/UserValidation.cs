using DTOs;

namespace Validation
{
    public class UserValidation
    {
     

        public static bool ValidatePassword(string Password)
        {
            if (Password.Length < 8)
            {
                return false;
            }
            bool HasUpper = false;
            bool HasLower = false;
            bool HasDigit = false;
            bool HasSpecial = false;

            for (int i = 0; i < Password.Length; i++)
            {
                if (char.IsUpper(Password[i]))
                {
                    HasUpper = true;
                }
                if (char.IsLower(Password[i]))
                {
                    HasLower = true;
                }
                if (char.IsDigit(Password[i]))
                {
                    HasDigit = true;
                }
                if (char.IsSymbol(Password[i]) || char.IsPunctuation(Password[i]))
                {
                    HasSpecial = true;
                }
            }
            return HasUpper && HasLower && HasDigit && HasSpecial;
        }

        public static bool ValidateEmail(string Email)
        {
            int Last = Email.Length - 5;

            if (!Email.EndsWith(".com"))
            {
                return false;
            }
            if (Email[Last] == '@' || Email[0] == '@')
            {
                return false;
            }

            bool HasAt = false;

            for (int i = 0; i <= Last; i++)
            {

                if (Email[i] == '@')
                {
                    if (HasAt == true)
                    {
                        return false;
                    }
                    HasAt = true;
                }

                if (Email[i] == ' ' || Email[i] == '.' || Email[i] == ',' || Email[i] == ';')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateStandard(string field)
        {
            return !string.IsNullOrEmpty(field);
        }

        public static bool ValidateUser(UserDto user)
        {
            return user is not null || ValidateStandard(user.FirstName) || ValidateStandard(user.LastName)
                || ValidateStandard(user.Phone) || ValidateEmail(user.Email) || ValidatePassword(user.Password); 
        }

    }
}
