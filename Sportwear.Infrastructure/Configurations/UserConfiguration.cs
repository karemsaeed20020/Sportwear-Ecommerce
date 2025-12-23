using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sportwear.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportwear.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // Set index on email to enhance search and make unique
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasMany(u => u.UserRefreshTokens)
                   .WithOne(rt => rt.User)
                   .HasForeignKey(rt => rt.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
