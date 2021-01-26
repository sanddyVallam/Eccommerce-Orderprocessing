using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public ICollection<Payments> Payment { get; set; } = new List<Payments>();
        public ICollection<ShippingDetails> Shipping { get; set; } = new List<ShippingDetails>();

    }
}
