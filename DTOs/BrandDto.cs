using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BrandDto
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }

        public BrandDto(int? id, string? name, string? imagePath)
        {
            this.ID = id;
            this.Name = name;
            this.ImagePath = imagePath;
        }

        public BrandDto()
        {
            this.ID = null;
            this.Name = null;
            this.ImagePath = null;
        }
    }
}
