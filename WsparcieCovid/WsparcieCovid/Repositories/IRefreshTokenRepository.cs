using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> Get(string token);
        Task<RefreshToken> Add(RefreshToken refreshToken);
        Task<RefreshToken> Update(RefreshToken refreshToken);
        Task Remove(string token);
    }
}