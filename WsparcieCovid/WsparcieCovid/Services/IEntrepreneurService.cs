using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IEntrepreneurService
    {
        Task<IActionResult> CreateAsync(string role, string login, string password,string firstName, string lastName, string email, string? name,
                    string? nipNumber,
                    string? bankAccountNumber,
                    string? phoneNumber);
        
        Task<IActionResult> GetAllAsync();
        
        Task<IActionResult> GetAsync(int userId);
        
        Task<IActionResult> UpdateAsync();
        
        Task<IActionResult> DeleteAsync();
    }
}