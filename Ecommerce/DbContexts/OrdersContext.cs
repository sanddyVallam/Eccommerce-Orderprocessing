using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DbContexts
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options) { }

        public DbSet<Orders> Orders { get; set; }   
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
    }   
}
