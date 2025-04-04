using ApiClients.ClientDtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClients
{
    public class ProductImagesApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductImagesApiClient(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<ProductImageDto> FindByIdAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"Find/{id}");

            return await GenericClientMethods.SendRequestAsync<ProductImageDto>(request, _httpClient);
        }

        public async Task<ProductImageDto> FindFirstImageByProductIdAsync(int productId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"FindFirstImage/{productId}");
            return await GenericClientMethods.SendRequestAsync<ProductImageDto>(request, _httpClient);
        }

        public async Task<ProductImageDto> FindByImagePathAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                throw new ArgumentNullException(nameof(imagePath), "Image path cannot be null or empty.");
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"FindByImagePath?imagePath={imagePath}");

            return await GenericClientMethods.SendRequestAsync<ProductImageDto>(request, _httpClient);
        }

        public async Task<ProductImageDto> SaveAsync(ProductImageDto productImageDto)
        {
            if (productImageDto is null)
            {
                throw new ArgumentNullException(nameof(productImageDto));
            }

            var request = new HttpRequestMessage(
                productImageDto.ID is null ? HttpMethod.Post : HttpMethod.Put,
                productImageDto.ID is null ? "Add" : "Update")
            {
                Content = new StringContent(JsonConvert.SerializeObject(productImageDto), Encoding.UTF8, "application/json")
            };

            return await GenericClientMethods.SendRequestAsync<ProductImageDto>(request, _httpClient);
        }

        public async Task<string> UploadProductImageAsync(string imageFilePath)
        {
            if (!File.Exists(imageFilePath))
            {
                throw new FileNotFoundException("Image file not found.", imageFilePath);
            }

            // Dynamically determine the MIME type
            var mimeType = GetMimeType(imageFilePath);
            var fileName = Path.GetFileName(imageFilePath);

            using (var fileStream = File.OpenRead(imageFilePath))
            using (var content = new StreamContent(fileStream))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

                var formData = new MultipartFormDataContent();
                formData.Add(content, "imageFile", fileName);

                var response = await _httpClient.PostAsync("Upload", formData);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to upload image: {errorMessage}");
                }

                // Configure case-insensitive JSON deserialization
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = await response.Content.ReadAsStringAsync();
                var uploadResult = JsonSerializer.Deserialize<UploadResult>(result, options);

                return uploadResult?.FilePath;
            }
        }

        // Helper method to get MIME type from file extension
        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            
            switch (extension)
            {
                case ".jpg": return "image/jpeg";
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                case ".svg": return "image/svg+xml";
                default: return "application/octet-stream";
            }
        }

        // Define UploadResult with JSON property mapping
        public class UploadResult
        {
            [JsonPropertyName("filePath")]
            public string FilePath { get; set; }
        }

        public async Task<string> DownloadProductImageAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "File name cannot be null or empty.");
            }

            var response = await _httpClient.GetAsync($"GetImage/{fileName}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to download image: {errorMessage}");
            }

            string saveFilePath = ConfigurationManager.AppSettings["ProductImageDirectory"] + fileName;

            using (var fileStream = File.Create(saveFilePath))
            {
                await response.Content.CopyToAsync(fileStream);
            }

            return saveFilePath;
        }

        public async Task<bool> DeleteByIdAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"Delete/{id}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> DeleteByImagePathAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                throw new ArgumentNullException(nameof(imagePath), "Image path cannot be null or empty.");
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, $"DeleteByImagePath?imagePath={imagePath}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> DeleteAllByProductIdAsync(int productId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"DeleteAll/{productId}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> DeleteAllByProductIdWithFilesAsync(int productId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"DeleteAllWithFiles/{productId}");
            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistByIdAsync(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExist/{id}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<bool> IsExistByImagePathAsync(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                throw new ArgumentNullException(nameof(imagePath), "Image path cannot be null or empty.");
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"IsExistByImagePath?imagePath={imagePath}");

            return await GenericClientMethods.SendRequestAsync<bool>(request, _httpClient);
        }

        public async Task<IEnumerable<ProductImageDto>> GetAllByProductIdAsync(int productId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"GetAll/{productId}");

            return await GenericClientMethods.SendRequestAsync<IEnumerable<ProductImageDto>>(request, _httpClient);
        }

    }
}