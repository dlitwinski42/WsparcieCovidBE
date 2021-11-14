using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Services
{
    public interface IEntrepreneurService
    {

        Task<IActionResult> GetAllAsync();
        
        Task<IActionResult> GetAsync(int userId);
        
        Task<IActionResult> UpdateAsync(Entrepreneur entrepreneur);
        
    }
}