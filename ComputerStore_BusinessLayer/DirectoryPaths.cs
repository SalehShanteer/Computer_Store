using Microsoft.Extensions.Configuration;

namespace ComputerStore_BusinessLayer
{
    public class DirectoryPaths
    {
        private readonly IConfiguration _configuration;

        public DirectoryPaths(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string? GetProductImagesDirectory()
        {
            return _configuration["ProductImagesDirectory"];
        }
    }
}