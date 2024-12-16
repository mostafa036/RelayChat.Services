using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelayChat.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RelayChat.Services.Persistence.Data.Configurations
{
    public class UserContactConfig : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> entity)
        {
            entity
             .HasKey(uc => new { uc.UserId, uc.ContactId });

            entity
            .HasOne(uc => uc.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(uc => uc.Contact)
            .WithMany(u => u.RelatedContacts)
            .HasForeignKey(uc => uc.ContactId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
