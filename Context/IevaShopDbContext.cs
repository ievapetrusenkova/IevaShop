using IevaShop.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace IevaShop.Context
{
    public class IevaShopDbContext : DbContext
    {
        public IevaShopDbContext(DbContextOptions<IevaShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Clothing> AllClothings { get; set; }

    }
}
