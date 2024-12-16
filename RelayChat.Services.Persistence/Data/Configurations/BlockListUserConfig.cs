using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelayChat.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Persistence.Data.Configurations
{
    public class BlockListUserConfig : IEntityTypeConfiguration<BlockListUser>
    {
        public void Configure(EntityTypeBuilder<BlockListUser> entity)
        {
            entity.HasKey(B => B.BlockListUserId);



            entity.HasOne(b => b.BlockingUser)
            .WithMany() // No navigation property on ApplicationUser for this side
            .HasForeignKey(b => b.BlockingUserId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete if needed

            // Configuring the relationship between BlockedUser and ApplicationUser
            entity.HasOne(b => b.BlockedUser)
                   .WithMany() // No navigation property on ApplicationUser for this side
                   .HasForeignKey(b => b.BlockedUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
