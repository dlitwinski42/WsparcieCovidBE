using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IGiftCardService
    {
        Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId, float amount);

        Task<IActionResult> GetAsync(int id);

        Task<IActionResult> GetAllAsync();
        
        Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId);

        Task<IActionResult> GetAllForContributorAsync(int contributorId);

        Task<IActionResult> SetStatusAsync(int id, string status);

        Task<IActionResult> GetActiveForEntrepreneurAsync(int entrepreneurId);

        Task<IActionResult> GetAvailableForEntrepreneurAsync(int entrepreneurId);
        
        Task<IActionResult> GetUsedForEntrepreneurAsync(int entrepreneurId);
        
        Task<IActionResult> GetUsedForContributorAsync(int contributorId);
    }
}