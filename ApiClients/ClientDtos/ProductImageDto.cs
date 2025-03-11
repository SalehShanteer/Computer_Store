using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class ProductImageDto
    {
        public int? ID;
        public string ImagePath;
        public int? ProductID;
        public byte? ImageOrder;

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
