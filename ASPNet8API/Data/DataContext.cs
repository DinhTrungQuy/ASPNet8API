using ASPNet8API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNet8API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
