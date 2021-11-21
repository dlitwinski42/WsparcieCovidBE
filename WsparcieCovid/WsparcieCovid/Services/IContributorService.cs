using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WsparcieCovid.Services
{
    public interface IContributorService
    {
        Task<IActionResult> GetAsync(int id);
    }
}