using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace ApiClients
{
    public class clsUtility
    {

        //Encryption and decryption
        private static readonly string key = ConfigurationManager.AppSettings["Key"];// Essential key
        private static readonly string iv = ConfigurationManager.AppSettings["iv"];// IV Key 

        private static readonly string keyPath = ConfigurationManager.AppSettings["KeyPath"];
        public static readonly string sourceName = ConfigurationManager.AppSettings["SourceName"];

        public static string Encrypt(string Text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(Text);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string EncryptedText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(EncryptedText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }

            }
        }


        // Validation
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
            return HasAt;
        }


        // Hashing
        public static string ComputeHash(string input)
        {
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }


        // Registry
        public static void WriteToRegistry(string Key, string Value)
        {
            try
            {
                // Write the value to the registry
                Registry.SetValue(keyPath, Key, Value);
            }
            catch (Exception ex)
            {
                // Log the error in the event log
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
        }

        public static string ReadFromRegistry(string Key)
        {
            if (_CheckIfRegistryKeyExists(Key))
            {
                try
                {
                    // Read the value from the registry
                    object value = Registry.GetValue(keyPath, Key, null);

                    return value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    // Log the error in the event log
                    EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        private static bool _CheckIfRegistryKeyExists(string Key)
        {
            try
            {
                // Check if the key exists
                return Registry.GetValue(keyPath, Key, null) != null;
            }
            catch (Exception ex)
            {
                // Log the error in the event log
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
                return false;
            }
        }
        

        // Validation
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

        // Formatting
        public static string DecimalToMoneyString(decimal? value)
            {
            return "$" + (value != null ? value?.ToString("F2") : "0.00");
        }

        public static string DateTimeToString(DateTime? value)
        {
            return value != null ? ((DateTime)value).ToString("dd/MM/yyyy") : "???";
        }

    }
}
