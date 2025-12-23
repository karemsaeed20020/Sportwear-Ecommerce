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
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasOne(rt => rt.User)
                   .WithMany(u => u.UserRefreshTokens)
                   .HasForeignKey(rt => rt.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
