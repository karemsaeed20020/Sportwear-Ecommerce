using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportwear.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
        public DateTime? BirthDate { get; set; }

        [MaxLength(100)]
        public string? Code { get; set; }


        // Navigation Property
        [InverseProperty(nameof(UserRefreshToken.User))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

    }
}
