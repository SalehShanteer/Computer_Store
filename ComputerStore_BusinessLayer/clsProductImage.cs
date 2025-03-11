using ComputerStore_DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;

namespace ComputerStore_BusinessLayer
{
    public class clsProductImage
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ID { get; set; }
        public string? ImagePath { get; set; }
        public int? ProductID { get; set; }
        public byte? ImageOrder { get; set; }

        public ProductImageDto ProductImageDto
        {
            get
            {
                return new ProductImageDto(this.ID, this.ImagePath, this.ProductID, this.ImageOrder);
            }
        }

        public clsProductImage()
        {
            this.ID = null;
            this.ImagePath = null;
            this.ProductID = null;
            this.ImageOrder = null;

            _Mode = enMode.AddNew;
        }

        public clsProductImage(ProductImageDto productImageDto, enMode mode)
        {
            this.ID = productImageDto.ID;
            this.ImagePath = productImageDto.ImagePath;
            this.ProductID = productImageDto.ProductID;
            this.ImageOrder = productImageDto.ImageOrder;

            _Mode = mode;
        }

        private bool AddNewProductImage()
        {
            this.ID = clsProductImageData.AddNewProductImage(this.ProductImageDto);
            return this.ID is not null;
        }

        private bool UpdateProductImage()
        {
            return clsProductImageData.UpdateProductImage(this.ProductImageDto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewProductImage())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }

                case enMode.Update:
                    {
                        return UpdateProductImage();
                    }
            }
            return false;
        }

        public static bool Delete(int id)
        {
            return clsProductImageData.DeleteProductImageByID(id);
        }

        public static bool Delete(string imagePath)
        {
            return clsProductImageData.DeleteProductImageByImagePath(imagePath);
        }

        public static clsProductImage Find(int id)
        {
            ProductImageDto productImageDto = clsProductImageData.GetProductImageByID(id);
            if (productImageDto is not null)
            {
                return new clsProductImage(productImageDto, enMode.Update);
            }
            return null;
        }

        public static clsProductImage Find(string imagePath)
        {
            ProductImageDto productImageDto = clsProductImageData.GetProductImageByImagePath(imagePath);
            if (productImageDto is not null)
            {
                return new clsProductImage(productImageDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int id)
        {
            return clsProductImageData.IsProductImageExistBy(id);
        }

        public static bool IsExist(string imagePath)
        {
            return clsProductImageData.IsProductImageExistImagePath(imagePath);
        }

        public static List<ProductImageDto> GetAllProductImagesRelated(int productID)
        {
            return clsProductImageData.GetAllProductImagesRelated(productID);
        }
    }
}