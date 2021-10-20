using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class EntrepreneurService : IEntrepreneurService
    {
        private IEntrepreneurRepository entrepreneurRepository;
        
        public EntrepreneurService(IEntrepreneurRepository entrepreneurRepository)
        {
            this.entrepreneurRepository = entrepreneurRepository;
        }

        Task<IActionResult> IEntrepreneurService.GetAllAsync()
        {
            return GetAllAsync();
        }

        Task<IActionResult> IEntrepreneurService.GetAsync(int userId)
        {
            return GetAsync(userId);
        }

        public Task<IActionResult> UpdateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> DeleteAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<IActionResult> GetAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> CreateAsync(string role, string login, string password, string firstName, string lastName, string email,
            string? name, string? nipNumber, string? bankAccountNumber, string? phoneNumber)
        {
            throw new System.NotImplementedException();
        }

        Task<IActionResult> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}