using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models
{
    public class OrderContext : DbContext{
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options){
            this.Database.EnsureCreated(); //自动建库建表
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<GoodsItem> GoodsItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
    }
}