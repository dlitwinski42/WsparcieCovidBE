using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext context;
        private readonly IReviewRepository reviewRepository;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IContributorRepository contributorRepository;

        public ReviewService(
                DataContext context,
                IReviewRepository reviewRepository,
                IEntrepreneurRepository entrepreneurRepository,
                IContributorRepository contributorRepository
            )
        {
            this.context = context;
            this.reviewRepository = reviewRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
        }
        public async Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId, int grade, string reviewBody)
        {
            var contributor = await contributorRepository.GetAsync(contributorId);
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            
            context.Database?.BeginTransactionAsync();
            var createdReview = await reviewRepository.AddAsync(new Review
            {
                Contributor = contributor,
                Entrepreneur = entrepreneur,
                Grade = grade,
                Timestamp = DateTime.Now,
                ReviewBody = reviewBody
            });
            
            context.Database?.CommitTransactionAsync();

            return new JsonResult(createdReview) {StatusCode = 201};
        }

        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await reviewRepository.GetAsync(id)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await reviewRepository.GetAllAsync()) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return new JsonResult(await reviewRepository.GetAllEntrepreneurAsync(entrepreneurId)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForContributorAsync(int contributorId)
        {
            return new JsonResult(await reviewRepository.GetAllContributorAsync(contributorId)) {StatusCode = 200};
        }
    }
}