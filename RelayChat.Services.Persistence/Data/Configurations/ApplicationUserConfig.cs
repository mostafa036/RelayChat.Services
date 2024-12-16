using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelayChat.Services.Domain.Entities;


namespace RelayChat.Services.Persistence.Data.Configurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.ToTable(nameof(ApplicationUser));

            entity.HasKey(U => U.Id);

            entity.Property(U => U.UserDisplay).HasMaxLength(150).IsRequired();

            entity.Property(U => U.Country).HasMaxLength(150);

            entity.Property(U => U.Language).HasMaxLength(150);

            entity.HasMany(U => U.Groups).WithMany(U => U.ApplicationUsers);

        }
    }
}
