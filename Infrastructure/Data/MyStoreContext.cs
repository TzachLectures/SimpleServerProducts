using Microsoft.EntityFrameworkCore;
using SimpleServerProducts.Core.Models;

namespace SimpleServerProducts.Infrastructure.Data
{
    public class MyStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        public MyStoreContext(DbContextOptions dbOptions) : base(dbOptions)
        {
        }

    }
}
