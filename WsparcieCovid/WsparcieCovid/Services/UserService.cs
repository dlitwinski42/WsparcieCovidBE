#nullable enable
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;
using WsparcieCovid.DTO;
using WsparcieCovid.Utils;

namespace WsparcieCovid.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext context;
        private readonly IJwtManager jwtManager;
        private readonly IUserRepository userRepository;
        private readonly IContributorRepository contributorRepository;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;

        private readonly string[] roles =
        {
            "Contributor", "Entrepreneur"
        };
        
        public UserService(
            DataContext context,
            IJwtManager jwtManager,
            IUserRepository userRepository,
            IContributorRepository contributorRepository,
            IEntrepreneurRepository entrepreneurRepository,
            IRefreshTokenRepository refreshTokenRepository
        )
        {
            this.context = context;
            this.jwtManager = jwtManager;
            this.userRepository = userRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
            this.refreshTokenRepository = refreshTokenRepository;
        }
        
        public async Task<IActionResult> CreateAsync(string role, string username, string password, string firstName, string lastName, string email,
            string? name,
            string? nipNumber,
            string? bankAccountNumber,
            string? phoneNumber)
        {
            var existingUser = await userRepository.GetAsync(username);

            if (existingUser != null)
            {
                return new JsonResult(new ExceptionDto {Message = "Username is already in use"}) {StatusCode = 422};
            }

            context.Database?.BeginTransactionAsync();

            var createdUser = await userRepository.AddAsync(new User
            {
                Username = username,
                PassHash = BCrypt.Net.BCrypt.HashPassword(password),
                FirstName =  firstName,
                LastName = lastName,
                Email = email
            });

            switch (role)
            {
                case "Contributor":
                    createdUser.Contributor = await contributorRepository.AddAsync(new Contributor {User = createdUser});
                    break;
                case "Entrepreneur":
                    createdUser.Entrepreneur = await entrepreneurRepository.AddAsync(new Entrepreneur
                    {
                        User = createdUser,
                        Name = name,
                        NipNumber = nipNumber,
                        BankAccountNumber = bankAccountNumber,
                        PhoneNumber = phoneNumber
                    });
                    break;
            }

            context.Database?.CommitTransactionAsync();

            return new JsonResult(createdUser) {StatusCode = 201};
        }

        public async Task<IActionResult> AuthenticateAsync(string login, string password)
        {
            var user = await userRepository.GetAsync(login);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PassHash))
            {
                return new JsonResult(new ExceptionDto {Message = "Invalid credentials"}) {StatusCode = 422};
            }

            var tokens = jwtManager.GenerateTokens(login, await GetRoleAsync(login), DateTime.Now);

            var handler = new JwtSecurityTokenHandler();
            var refreshData = handler.ReadJwtToken(tokens.RefreshToken);
            var date = refreshData.ValidTo;

            await refreshTokenRepository.Add(new RefreshToken {Token = tokens.RefreshToken, ValidTill = date});

            return new JsonResult(tokens);
        }

        public async Task<IActionResult> RefreshAsync(string accessToken, string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetRoleAsync(string login)
        {
            var user = await userRepository.GetAsync(login);
            if (user.Contributor != null)
            {
                return "Contributor";
            }
            return "Entrepreneur";
        }

        public Task<object> GetCurrentUserAsync(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}