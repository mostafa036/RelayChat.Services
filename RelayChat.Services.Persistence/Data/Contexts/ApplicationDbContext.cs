using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RelayChat.Services.Domain.Entities;


namespace RelayChat.Services.Persistence.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<BlockListUser> BlockListUsers { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
      
            base.OnModelCreating(builder);   
        }
    }
}
