using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ModelDTO;

namespace Ecommerce.ModelDTO
{
    public class CreateOrderDTO
    {
        [Required]
        public string Name { get; set; }  
        [Required]
        public int Quantity { get; set; } 
        [Required]
        public decimal costPerItem { get; set; }
        public ICollection<CreatePaymentDTO> Payment { get; set; } = new List<CreatePaymentDTO>();
        public CreateShippingDetailDTO Shipping { get; set; } = new CreateShippingDetailDTO();
    }
}
