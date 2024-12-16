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
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> entity)
        {
            entity.HasKey(d => d.DeviceId);

            // Property Configurations
            entity.Property(d => d.DeviceType)
                   .IsRequired()
                   .HasMaxLength(50);  

            entity.Property(d => d.DeviceName)
                   .HasMaxLength(100);  

            entity.Property(d => d.DeviceOS)
                   .IsRequired()
                   .HasMaxLength(50);  

            entity.Property(d => d.DeviceToken)
                   .HasMaxLength(250);  

            entity.Property(d => d.DeviceModel)
                   .HasMaxLength(100);  

            entity.Property(d => d.Manufacturer)
                   .HasMaxLength(100); 

            entity.Property(d => d.LastAccessed).IsRequired();  

            // Relationship Configuration with ApplicationUser
            entity.HasOne(d => d.ApplicationUser)
                   .WithOne(u => u.Device)
                   .HasForeignKey<Device>(d => d.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
