using System;

namespace ApiClients.ClientDtos
{
    public class PaymentMethodDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public PaymentMethodDto()
        {
            this.ID = null;
            this.Name = null;
        }

        public PaymentMethodDto(int? id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}