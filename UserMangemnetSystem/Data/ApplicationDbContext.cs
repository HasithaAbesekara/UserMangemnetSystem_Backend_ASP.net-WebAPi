using Microsoft.EntityFrameworkCore;
using UserMangemnetSystem.Models.Entites;

namespace UserMangemnetSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        //{

        //}
        //auto genrate using click in class name and press ctrl
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntities { get; set; }
    }
}
