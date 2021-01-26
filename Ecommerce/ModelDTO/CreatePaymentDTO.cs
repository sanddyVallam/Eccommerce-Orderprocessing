using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ModelDTO
{
    public class CreatePaymentDTO
    {
        [Required]
        public string paymentmethod { get; set; }
        [Required]
        public decimal Paymentamount { get; set; }
        public string BillingAdd1 { get; set; }        
        public string BillingAdd2 { get; set; }

        
        public string City { get; set; }

        
        public string State { get; set; }

        
        public string Zip { get; set; }

        
    }
}
