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
    public class GroupsConfig : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> entity)
        {
            entity.HasKey(g => g.GroupId);

            entity.HasMany(g => g.ApplicationUsers)
              .WithMany(g => g.Groups);

            entity.Property(g => g.Name)
               .IsRequired()
               .HasMaxLength(100);

            entity.Property(g => g.Description)
             .HasMaxLength(250);
        }
    }
}
