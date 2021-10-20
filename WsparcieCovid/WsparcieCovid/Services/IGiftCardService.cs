using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IGiftCardService
    {
        Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId);

        Task<IActionResult> GetAsync(int id);

        Task<IActionResult> GetAllAsync();
        
        Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId);

        Task<IActionResult> GetAllForContributorAsync(int contributorId);

        Task<IActionResult> SetStatusAsync(int id, string status);
    }
}