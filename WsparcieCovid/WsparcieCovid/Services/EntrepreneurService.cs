using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class EntrepreneurService : IEntrepreneurService
    {
        private IEntrepreneurRepository entrepreneurRepository;
        
        public EntrepreneurService(IEntrepreneurRepository entrepreneurRepository)
        {
            this.entrepreneurRepository = entrepreneurRepository;
        }
        

        public async Task<IActionResult> UpdateAsync(Entrepreneur entrepreneur)
        {
            return new JsonResult(await entrepreneurRepository.UpdateAsync(entrepreneur));
        }

        public async Task<IActionResult> GetAsync(int entrepreneurId)
        {
            return new JsonResult(await entrepreneurRepository.GetAsync(entrepreneurId)) {StatusCode = 200};
        }


        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await entrepreneurRepository.GetAllAsync()) {StatusCode = 200};
        }
    }
}