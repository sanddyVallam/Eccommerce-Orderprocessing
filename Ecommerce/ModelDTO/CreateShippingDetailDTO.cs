using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ModelDTO
{
    public class CreateShippingDetailDTO
    {
        [Required]
        public string ShippingType { get; set; }        
        public string ShippingAdd1 { get; set; }        
        public string ShippingAdd2 { get; set; }        
        public string City { get; set; }        
        public string State { get; set; }        
        public string Zip { get; set; }

        
    }
}
