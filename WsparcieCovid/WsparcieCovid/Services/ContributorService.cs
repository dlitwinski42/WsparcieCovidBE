using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class ContributorService : IContributorService
    {
        private readonly DataContext context;
        private readonly IContributorRepository contributorRepository;

        public ContributorService(
            DataContext context,
            IContributorRepository contributorRepository
        )
        {
            this.context = context;
            this.contributorRepository = contributorRepository;
        }
        
        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await contributorRepository.GetAsync(id)) {StatusCode = 200};
        }
    }
}