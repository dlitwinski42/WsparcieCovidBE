using System;
using System.ComponentModel.DataAnnotations;

namespace WsparcieCovid.DTO
{
    public class AuthenticationDto
    {
        [Required] public string AccessToken { get; set; }

        [Required] public string RefreshToken { get; set; }

        [Required] public string Role { get; set; }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                AuthenticationDto other => AccessToken == other.AccessToken && RefreshToken == other.RefreshToken &&
                                           Role == other.Role,
                _ => base.Equals(obj)
            };
        }

        protected bool Equals(AuthenticationDto other)
        {
            return AccessToken == other.AccessToken && RefreshToken == other.RefreshToken && Role == other.Role;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccessToken, RefreshToken, Role);
        }
    }
}