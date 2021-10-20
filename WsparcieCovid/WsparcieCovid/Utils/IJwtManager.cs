using System;
using WsparcieCovid.DTO;

namespace WsparcieCovid.Utils
{
    public interface IJwtManager
    {
        AuthenticationDto GenerateTokens(string username, string role, DateTime startDate);
        bool ContainsRefreshToken(string refreshToken);
    }
}