using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IProductService
    {
        Task<IActionResult> CreateAsync(int entrepreneurId, string name, string description, float price);
        
        Task<IActionResult> GetAsync(int id);
        
        Task<IActionResult> GetAllAsync();

        Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId);
    }
}