using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class GiftCardsController
    {
        private readonly IGiftCardService giftCardService;
        
        public GiftCardsController(
            IGiftCardService giftCardService)
        {
            this.giftCardService = giftCardService;
        }
        
        [HttpPost("/giftcard")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] GiftCardDto giftCardDto)
        {
            return await giftCardService.CreateAsync(giftCardDto.ContributorId,giftCardDto.EntrepreneurId, giftCardDto.Amount);
        }
        
        [HttpGet("/giftcard")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await giftCardService.GetAllAsync();
        }
        
        [HttpGet("/giftcard/{id}/paid")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> SetPaidAsync(int id)
        {
            return await giftCardService.SetStatusAsync(id, "Paid");
        }
        
        [HttpGet("/giftcard/{id}/used")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> SetUsedAsync(int id)
        {
            return await giftCardService.SetStatusAsync(id, "Used");
        }
        
        [HttpGet("/giftcard/contributor/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllForContributorAsync(int contributorId)
        {
            return await giftCardService.GetAllForContributorAsync(contributorId);
        }
        
        [HttpGet("/giftcard/entrepreneur/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return await giftCardService.GetAllForEntrepreneurAsync(entrepreneurId);
        }
        
        [HttpGet("/giftcard/active/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActiveForEntrepreneur(int entrepreneurId)
        {
            return await giftCardService.GetActiveForEntrepreneurAsync(entrepreneurId);
        }
        
        [HttpGet("/giftcard/available/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableForEntrepreneur(int entrepreneurId)
        {
            return await giftCardService.GetAvailableForEntrepreneurAsync(entrepreneurId);
        }
        
        [HttpGet("/giftcard/used/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsedForEntrepreneur(int entrepreneurId)
        {
            return await giftCardService.GetUsedForEntrepreneurAsync(entrepreneurId);
        }
        
        [HttpGet("/giftcard/history/{contributorId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsedForContributor(int contributorId)
        {
            return await giftCardService.GetUsedForContributorAsync(contributorId);
        }
    }
}