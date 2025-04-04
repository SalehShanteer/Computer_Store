
namespace ApiClients.ClientDtos
{
    public class ProductImageDto
    {
        public int? ID { get; set; }
        public string ImagePath { get; set; }
        public int? ProductID { get; set; }
        public byte? ImageOrder { get; set; }

        public ProductImageDto()
        {
            this.ID = null;
            this.ImagePath = null;
            this.ProductID = null;
            this.ImageOrder = null;
        }

        public ProductImageDto(int? id, string imagePath, int? productID, byte? imageOrder)
        {
            this.ID = id;
            this.ImagePath = imagePath;
            this.ProductID = productID;
            this.ImageOrder = imageOrder;
        }
    }
}
