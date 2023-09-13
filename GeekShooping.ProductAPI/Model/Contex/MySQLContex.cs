using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Contex
{
    public class MySQLContex : DbContext
    {
        public MySQLContex() {}
        public MySQLContex(DbContextOptions<MySQLContex> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
    }
}
