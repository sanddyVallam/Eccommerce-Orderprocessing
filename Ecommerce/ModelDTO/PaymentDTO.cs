using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ModelDTO
{
    public class PaymentDTO
    {
        public string PaymentDetails { get; set; }
        public string paymentmethod { get; set; }
        public string Paymentdate { get; set; }
        public string PaymentConfirmation { get; set; }

    }
}
