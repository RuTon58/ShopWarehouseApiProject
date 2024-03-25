using Microsoft.EntityFrameworkCore;
using ShopApi.Core.Domain.Models;

namespace ShopApi.Core.Application.Data{
    public class ApplicationDbContext : DbContext{
        public DbSet<Ware> Wares { get; set; }
        public DbSet<WareUnitType> WareUnitTypes { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}