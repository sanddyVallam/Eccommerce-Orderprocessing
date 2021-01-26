using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
        public string paymentmethod { get; set; }
        public string Paymentdate { get; set; }
        public string PaymentConfirmation { get; set; }

        [MaxLength(200)]
        public string BillingAdd1 { get; set; }

        [MaxLength(200)]
        public string BillingAdd2 { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(200)]
        public string State { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }

        [ForeignKey("OrderId")]
        public Orders Order { get; set; }
        public int OrderId { get; set; }
    }
}
