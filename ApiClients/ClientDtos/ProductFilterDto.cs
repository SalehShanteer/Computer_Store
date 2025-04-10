using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class ProductFilterDto
    {
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public int? BrandID { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public ProductFilterDto()
        {
            this.Name = null;
            this.CategoryID = null;
            this.SubCategoryID = null;
            this.BrandID = null;
            this.MinPrice = null;
            this.MaxPrice = null;
        }

        public ProductFilterDto(string name, int? categoryID, int? SubcategoryID, int? brandID, decimal? minPrice, decimal? maxPrice)
        {
            this.Name = name;
            this.CategoryID = categoryID;
            this.SubCategoryID = SubcategoryID;
            this.BrandID = brandID;
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
        }
    }
}
