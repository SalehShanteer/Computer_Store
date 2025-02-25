using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductDto
    {

        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public short? QuantityInStock { get; set; }
        public int? CategoryID { get; set; }
        public int? SubcategoryID { get; set; }
        public int? BrandID { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public ProductDto()
        {
            this.ID = null;
            this.Name = null;
            this.Description = null;
            this.Price = null;
            this.QuantityInStock = null;
            this.CategoryID = null;
            this.SubcategoryID = null;
            this.BrandID = null;
            this.Rating = null;
            this.ReleaseDate = null;
        }

        public ProductDto(int? id, string? name, string? description, decimal? price, short? quantityInStock
            , int? categoryID, int? subcategory, int? brandID, decimal? rating, DateTime? releaseDate)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.QuantityInStock = quantityInStock;
            this.CategoryID = categoryID;
            this.SubcategoryID = subcategory;
            this.BrandID = brandID;
            this.Rating = rating;
            this.ReleaseDate = releaseDate;
        }

    }
}
