﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IUserService
    {
        Task<IActionResult> CreateAsync(string role, string login, string password,string firstName, string lastName, string email, string? name,
            string? nipNumber,
            string? bankAccountNumber,
            string? phoneNumber);
        
        Task<IActionResult> AuthenticateAsync(string login, string password);

        Task<IActionResult> RefreshAsync(string accessToken, string refreshToken);

        Task<string> GetRoleAsync(string login);

        Task<object> GetCurrentUserAsync(HttpRequest request);
    }
}