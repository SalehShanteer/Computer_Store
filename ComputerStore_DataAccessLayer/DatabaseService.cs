using Microsoft.Extensions.Configuration;
using System;

namespace ComputerStore_DataAccessLayer
{
    public static class DatabaseConfiguration
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public static string? GetConnectionString()
        {
            return _configuration?.GetConnectionString("cs");
        }

        public static string? GetSourceName()
        {
            return _configuration?["SourceName"];
        }
    }
}
