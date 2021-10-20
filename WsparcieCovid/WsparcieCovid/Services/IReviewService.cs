using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IReviewService
    {
        Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId, int grade, string reviewBody);
        
        Task<IActionResult> GetAsync(int id);
        
        Task<IActionResult> GetAllAsync();

        Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId);

        Task<IActionResult> GetAllForContributorAsync(int contributorId);

    }
}