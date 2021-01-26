using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ModelDTO
{
    public class OrdersDTO
    {
        
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Total { get; set; }
        public string CreatedDate { get; set; }
        public string  ModifiedDate { get; set; }        
        public List<PaymentDTO> Payment { get; set; }                                 
        public List<ShippingDetailDTO> Shipping { get; set; }       
        

    }
}
