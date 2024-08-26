
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
namespace WebAPI.Data

{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserDto> Users { get; set; }

    }
}