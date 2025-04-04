

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class ProductDetailsDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public short? QuantityInStock { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Brand { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ProductDetailsDto()
        {
            this.ID = null;
            this.Name = null;
            this.Description = null;
            this.Price = null;
            this.QuantityInStock = null;
            this.Category = null;
            this.Subcategory = null;
            this.Brand = null;
            this.Rating = null;
            this.ReleaseDate = null;
        }

        public ProductDetailsDto(int? id, string name, string description, decimal? price, short? quantityInStock
            , string category, string subcategory, string brand, decimal? rating, DateTime? releaseDate)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.QuantityInStock = quantityInStock;
            this.Category = category;
            this.Subcategory = subcategory;
            this.Brand = brand;
            this.Rating = rating;
            this.ReleaseDate = releaseDate;
        }

    }
}
