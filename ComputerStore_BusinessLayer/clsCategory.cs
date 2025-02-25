using ComputerStore_DataAccessLayer;
using DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore_BusinessLayer
{
    public class clsCategory
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ID { get; set; }
        public string? Name { get; set; }

        public CategoryDto categoryDto { get { return new(this.ID, this.Name); } }

        public clsCategory(CategoryDto categoryDto, enMode mode)
        {
            this.ID = categoryDto.ID;
            this.Name = categoryDto.Name;

            _Mode = mode;
        }

        public clsCategory()
        {
            this.ID = null;
            this.Name = null;

            _Mode = enMode.AddNew;
        }

        private bool _AddNewCategory()
        {
            this.ID = clsCategoryData.AddNewCategory(this.categoryDto);
            return this.ID is not null;
        }

        private bool _UpdateCategory()
        {
            return clsCategoryData.UpdateCategory(this.categoryDto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewCategory())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCategory();
            }
            return false;
        }

        public static clsCategory Find(int? id)
        {
            CategoryDto categoryDto = clsCategoryData.GetCategoryByID(id);

            if (categoryDto is not null)
            {
                return new clsCategory(categoryDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? id)
        {
            return clsCategoryData.IsCategoryExist(id);
        }   

        public static bool Delete(int id)
        {
            return clsCategoryData.DeleteCategory(id);
        }

        public static List<CategoryDto> GetAll()
        {
            return clsCategoryData.GetAllCategories();
        }

    }
}
