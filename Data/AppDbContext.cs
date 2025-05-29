using Batch27WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Batch27WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<BookMenu> Books{ get; set; }
    }
}
