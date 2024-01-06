using FloodChasersModel.Alerts;
using FloodChasersModel.Commons;
using FloodChasersModel.Users;
using Microsoft.EntityFrameworkCore;

namespace FloodChasersLogic.Dao
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
