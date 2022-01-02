using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IDonationService
    {
        Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId, float amount);
        Task<IActionResult> GetAsync(int id);
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> ConfirmAsync(int id);
        Task<IActionResult> SendAsync(int id);
        Task<IActionResult> GetActiveForEntrepreneurAsync(int entrepreneurId);
        
        Task<IActionResult> GetConfirmedForEntrepreneurAsync(int entrepreneurId);
        
        Task<IActionResult> GetConfirmedForContributorAsync(int contributorId);
    }
}