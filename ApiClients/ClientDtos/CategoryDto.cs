﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class CategoryDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public CategoryDto()
        {
            this.ID = null;
            this.Name = null;
        }

        public CategoryDto(int? id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

    }
}
