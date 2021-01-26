using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class ShippingDetails
    {
        [Key]
        public int Id { get; set; }
        public string ShippingType { get; set; }

        [MaxLength(200)]
        public string ShippingAdd1 { get; set; }

        [MaxLength(200)]
        public string ShippingAdd2 { get; set; }

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
