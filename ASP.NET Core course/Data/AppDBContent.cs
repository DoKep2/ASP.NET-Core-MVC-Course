using ASP.NET_Core_course.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP.NET_Core_course.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}