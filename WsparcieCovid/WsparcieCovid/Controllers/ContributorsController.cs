using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class ContributorsController
    {
        private readonly IContributorService contributorService;
        
        public ContributorsController(
            IContributorService contributorService
        )
        {
            this.contributorService = contributorService;
        }
        
        [HttpGet("/contributor/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await contributorService.GetAsync(id);
        }
    }
}