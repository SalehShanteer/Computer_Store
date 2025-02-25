using ComputerStore_DataAccessLayer;
using DTOs;


namespace ComputerStore_BusinessLayer
{
    public class clsBrand
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }

        public BrandDto brandDto { get { return new(this.ID, this.Name, this.ImagePath); } }

        public clsBrand(BrandDto brandDto, enMode mode)
        {
            this.ID = brandDto.ID;
            this.Name = brandDto.Name;
            this.ImagePath = brandDto.ImagePath;

            _Mode = mode;
        }

        public clsBrand()
        {
            this.ID = null;
            this.Name = null;
            this.ImagePath = null;
            _Mode = enMode.AddNew;
        }

        private bool _AddNewBrand()
        {
            this.ID = clsBrandData.AddNewBrand(this.brandDto);
            return this.ID is not null;
        }

        private bool _UpdateBrand()
        {
            return clsBrandData.UpdateBrand(this.brandDto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewBrand())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _UpdateBrand();
            }
            return false;
        }

        public static clsBrand Find(int? id)
        {
            BrandDto brandDto = clsBrandData.GetBrandByID(id);
            if (brandDto is not null)
            {
                return new clsBrand(brandDto, enMode.Update);
            }
            return null;
        }

        public static bool IsExist(int? id)
        {
            return clsBrandData.IsBrandExist(id);
        }

        public static bool Delete(int? id)
        {
            return clsBrandData.DeleteBrand(id);
        }

        public static List<BrandDto> GetAll()
        {
            return clsBrandData.GetAllBrands();
        }

    }
}
