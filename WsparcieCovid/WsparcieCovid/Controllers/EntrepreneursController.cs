using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class EntrepreneursController
    {
        private readonly IEntrepreneurService entrepreneurService;

        public EntrepreneursController(
            IEntrepreneurService entrepreneurService)
        {
            this.entrepreneurService = entrepreneurService;
        }
        
        [HttpGet("/entrepreneur")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await entrepreneurService.GetAllAsync();
        }

        [HttpGet("/entrepreneur/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetAsync(int id)
        {
            return await entrepreneurService.GetAsync(id);
        }
        

    }
}