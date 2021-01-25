using Microsoft.EntityFrameworkCore;
using voetbal_api.Models;

namespace voetbal_api.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}