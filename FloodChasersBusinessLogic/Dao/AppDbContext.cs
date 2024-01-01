using FloodChasersModel.Commons;
using FloodChasersModel.Users;
using Microsoft.EntityFrameworkCore;

namespace FloodChasersLogic.Dao
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Email = "1",FirstName = "Chen", LastName = "Maimon",Password = "s", ProfileImage = new ImageData {Url = "s"} }
        //        );
        //}


    }
}
