using Microsoft.EntityFrameworkCore;
using Sportwear.Data.Entities.Identity;
using Sportwear.Infrastructure.Abstracts;
using Sportwear.Infrastructure.Context;
using Sportwear.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportwear.Infrastructure.Repository
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            userRefreshToken = dbContext.Set<UserRefreshToken>();
        }
        #endregion

        
    }
}
