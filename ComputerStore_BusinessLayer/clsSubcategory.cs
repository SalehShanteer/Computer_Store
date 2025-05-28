using ComputerStore_DataAccessLayer;
using DTOs;

namespace ComputerStore_BusinessLayer
{
    public class clsSubcategory
    {
        public enum enMode { AddNew, Update}
        private enMode _Mode;

        public int? ID { get; set; }
        public string? Name { get; set; }
        public int? CategoryID { get; set; }
        public clsCategory CategoryInfo { get; }
        public SubcategoryDto subcategoryDto { get { return new(this.ID, this.Name, this.CategoryID); } }



        public clsSubcategory(SubcategoryDto subcategoryDto, enMode mode)
        {
            this.ID = subcategoryDto.ID;
            this.Name = subcategoryDto.Name;
            this.CategoryID = subcategoryDto.CategoryID;
            this.CategoryInfo = clsCategory.Find(subcategoryDto.CategoryID);

            _Mode = mode;
        }

        public clsSubcategory()
        {
            this.ID = null;
            this.Name = null;
            this.CategoryID = null;
            this.CategoryInfo = new clsCategory();

            _Mode = enMode.AddNew;

        }

        private bool _AddNewSubcategory()
        {
            this.ID = clsSubcategoryData.AddNewSubcategory(this.subcategoryDto);
            return this.ID is not null;
        }

        private bool _UpdateSubcategory()
        {
            return clsSubcategoryData.UpdateSubcategory(this.subcategoryDto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewSubcategory())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _UpdateSubcategory();       
            }
            return false;
        }

        public static clsSubcategory Find(int? id)
        {
            SubcategoryDto subcategoryDto = clsSubcategoryData.GetSubcategoryByID(id);
            if (subcategoryDto is not null)
            {
                return new clsSubcategory(subcategoryDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? id)
        {
            return clsSubcategoryData.IsSubcategoryExist(id);
        }

        public static bool IsExist(string name, int? categoryID)
        {
            return clsSubcategoryData.IsSubcategoryNameExist(name, categoryID);
        }

        public static bool IsSubcategoryBelongsToCategory(int? SubcategoryID, int? categoryID)
        {
            return clsSubcategoryData.IsSubcategoryBelongsToCategory(SubcategoryID, categoryID);
        }

        public static bool Delete(int? id)
        {
            return clsSubcategoryData.DeleteSubcategory(id);
        }

        public static List<SubcategoryDto> GetAll()
        {
            return clsSubcategoryData.GetAllSubcategories();
        }

        public static List<SubcategoryDto> GetSubcategoriesByCategoryID(int? categoryID)
        {
            return clsSubcategoryData.GetSubcategoriesByCategoryID(categoryID);
        }

    }
}
