using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DataContext context;

        public RefreshTokenRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<RefreshToken> Get(string token)
        {
            return await context.RefreshTokens.FirstOrDefaultAsync(refreshToken => refreshToken.Token == token);
        }

        public async Task<RefreshToken> Add(RefreshToken refreshToken)
        {
            var result = await context.RefreshTokens.AddAsync(refreshToken);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<RefreshToken> Update(RefreshToken refreshToken)
        {
            var result = context.RefreshTokens.Update(refreshToken);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task Remove(string token)
        {
            var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

            if (refreshToken != null)
            {
                context.RefreshTokens.Remove(refreshToken);
                await context.SaveChangesAsync();
            }
        }
    }
}