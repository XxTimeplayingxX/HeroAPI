using HeroAPI.MODELS;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.DATA
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            :base (options)
        {
            
        }
        public DbSet<Hero> Hero { get; set; }
    }
}
