using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.ClientDtos
{
    public class OrderStatusDto
    {
        public int? ID { get; set; }
        public byte? Status { get; set; }

        public OrderStatusDto()
        {
            this.ID = null;
            this.Status = null;
        }

        public OrderStatusDto(int? id, byte? status)
        {
            this.ID = id;
            this.Status = status;
        }
    }
}
