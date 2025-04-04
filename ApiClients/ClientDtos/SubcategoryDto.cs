using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class SubcategoryDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }

        public SubcategoryDto(int? id, string name, int? categoryID)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
        }

        public SubcategoryDto()
        {
            this.ID = null;
            this.Name = null;
            this.CategoryID = null;
        }

    }
}
