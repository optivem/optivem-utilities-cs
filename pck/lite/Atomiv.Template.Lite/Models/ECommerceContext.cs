using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;

// TODO VC TodoApi.Models
namespace Atomiv.Template.Lite.Models
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        // public DbSet<Customer> Customers { get; set; }

        // this  was automatically generated TODO VC
        // should it be a plural or not
        // public DbSet<Atomiv.Template.Lite.Models.Product> Product { get; set; }

        // this  was automatically generated TODO VC
        // public DbSet<Atomiv.Template.Lite.Models.Order> Order { get; set; }
        // public DbSet<Product> Products { get; set; }
        // public DbSet<Atomiv.Template.Lite.Models.OrderItem> OrderItems { get; set; }
        // public virtual DbSet<Category> Category { get; set; }
    }
}