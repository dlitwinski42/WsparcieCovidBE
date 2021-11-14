using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IOrderService
    {
        Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId);

        Task<IActionResult> GetAsync(int id);

        Task<IActionResult> GetAllAsync();

        Task<IActionResult> AddProduct(int orderId, int productId);

        Task<IActionResult> ChangeStatusAsync(int id, string status);
        
        
    }
}