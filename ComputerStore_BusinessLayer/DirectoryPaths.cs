using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore_BusinessLayer
{
    public class DirectoryPaths
    {

        private static IConfiguration _Configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public static string? GetProductImagesDirectory()
        {
            return _Configuration?["ProductImagesDirectory"];
        }

    }
}
