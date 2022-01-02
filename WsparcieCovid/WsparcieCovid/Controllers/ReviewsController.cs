using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class ReviewsController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(
            IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        
        [HttpPost("/review")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] ReviewDTO reviewDto)
        {
            return await reviewService.CreateAsync(reviewDto.ContributorId,reviewDto.EntrepreneurId,reviewDto.Grade,reviewDto.ReviewBody);
        }
        
        [HttpGet("/review/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await reviewService.GetAsync(id);
        }
        
        [HttpGet("/review")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await reviewService.GetAllAsync();
        }
        
        [HttpGet("/review/contributor/{contributorId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllForContributorAsync(int contributorId)
        {
            return await reviewService.GetAllForContributorAsync(contributorId);
        }
        
        [HttpGet("/review/entrepreneur/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return await reviewService.GetAllForEntrepreneurAsync(entrepreneurId);
        }
    }
}