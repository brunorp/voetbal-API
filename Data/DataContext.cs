using Microsoft.EntityFrameworkCore;
using voetbal_api.Models;

namespace voetbal_api.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>().HasMany(team => team.Players)
            .WithOne(player => player.Team);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}