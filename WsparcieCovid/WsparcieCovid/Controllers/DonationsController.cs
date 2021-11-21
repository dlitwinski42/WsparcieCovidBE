using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{

    public class DonationsController
    {
        private readonly IDonationService donationService;

        public DonationsController(
            IDonationService donationService
            )
        {
            this.donationService = donationService;
        }
        
        [HttpPost("/donation")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] DonationDto donationDto)
        {
            return await donationService.CreateAsync(donationDto.ContributorId,donationDto.EntrepreneurId,donationDto.Amount);
        }

        [HttpGet("/donation")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await donationService.GetAllAsync();
        }
        
        [HttpGet("/donation/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await donationService.GetAsync(id);
        }
        
        
        [HttpGet("/donation/{id}/confirm")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmAsync(int id)
        {
            return new JsonResult(await donationService.ConfirmAsync(id));
        }
        
        [HttpGet("/donation/{id}/send")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> SendAsync(int id)
        {
            return new JsonResult(await donationService.SendAsync(id));
        }
        
        [HttpGet("/donation/active/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActiveForEntrepreneur(int entrepreneurId)
        {
            return await donationService.GetActiveForEntrepreneurAsync(entrepreneurId);
        }
    }
}