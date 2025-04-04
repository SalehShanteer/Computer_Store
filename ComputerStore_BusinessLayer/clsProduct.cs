using ComputerStore_DataAccessLayer;
using DTOs;
using System;

namespace ComputerStore_BusinessLayer
{
    public class clsProduct
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

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

        public ProductDto ProductDto
        {
            get
            {
                return new ProductDto(this.ID, this.Name, this.Description, this.Price, this.QuantityInStock
                    , this.CategoryID, this.SubcategoryID, this.BrandID, this.Rating, this.ReleaseDate);
            }
        }

        public clsProduct()
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

            _Mode = enMode.AddNew;
        }

        public clsProduct(ProductDto productDto, enMode mode)
        {
            this.ID = productDto.ID;
            this.Name = productDto.Name;
            this.Description = productDto.Description;
            this.Price = productDto.Price;
            this.QuantityInStock = productDto.QuantityInStock;
            this.CategoryID = productDto.CategoryID;
            this.SubcategoryID = productDto.SubcategoryID;
            this.BrandID = productDto.BrandID;
            this.Rating = productDto.Rating;
            this.ReleaseDate = productDto.ReleaseDate;

            _Mode = mode;
        }

        private bool AddNewProduct()
        {
            this.ID = clsProductData.AddNewProduct(this.ProductDto);
            return this.ID is not null;
        }

        private bool UpdateProduct()
        {
            return clsProductData.UpdateProduct(this.ProductDto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewProduct())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }

                case enMode.Update:
                    {
                        return UpdateProduct();
                    }
            }
            return false;
        }

        public static bool Delete(int id)
        {
            return clsProductData.DeleteProduct(id);
        }

        public static clsProduct Find(int id)
        {
            ProductDto productDto = clsProductData.GetProductByID(id);
            if (productDto is not null)
            {
                return new clsProduct(productDto, enMode.Update);
            }
            return null;
        }

        public static clsProduct Find(string name)
        {
            ProductDto productDto = clsProductData.GetProductByName(name);
            if (productDto is not null)
            {
                return new clsProduct(productDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? id)
        {
            return clsProductData.IsProductExistID(id);
        }

        public static List<ProductDto> GetAllProducts()
        {
            return clsProductData.GetAllProducts();
        }

        public static List<ProductDetailsDto> GetAllProductsDetails()
        {
            return clsProductData.GetAllProductsDetails();
        }

    }
}
