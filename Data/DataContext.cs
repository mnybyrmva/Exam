using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studio.Models;

namespace Studio.Data
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Team> teams { get; set; }
        public DbSet<Profession> professions { get; set; }
        public DbSet<AppUser> appusers { get; set; }
        public DbSet<Setting> settings { get; set; }
    }
}
