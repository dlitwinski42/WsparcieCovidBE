using System;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class DonationService : IDonationService
    {
        private readonly DataContext context;
        private readonly IDonationRepository donationRepository;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IContributorRepository contributorRepository;

        public DonationService(
            DataContext context,
            IDonationRepository donationRepository,
            IEntrepreneurRepository entrepreneurRepository,
            IContributorRepository contributorRepository)
        {
            this.context = context;
            this.donationRepository = donationRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
        }
        public async Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId, float amount)
        {
            
            var contributor = await contributorRepository.GetAsync(contributorId);
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            
            context.Database?.BeginTransactionAsync();
            var createdDonation = await donationRepository.AddAsync(new Donation
            {
                Contributor = contributor,
                Entrepreneur = entrepreneur,
                Amount = amount,
                Status = DonationStatus.Sent,
                DateSent = DateTime.Now
            });
            
            context.Database?.CommitTransactionAsync();

            return new JsonResult(createdDonation) {StatusCode = 201};
        }

        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await donationRepository.GetAsync(id)) {StatusCode = 200};
        }
        
        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await donationRepository.GetAllAsync()) {StatusCode = 200};
        }

        public async Task<IActionResult> ConfirmAsync(int id)
        {
            var donation = await donationRepository.GetAsync(id);
            donation.Status = DonationStatus.Confirmed;
            donation.DateConfirmed = DateTime.Now;
            await donationRepository.UpdateAsync(donation);
            return new JsonResult(donation) {StatusCode = 200};

        }
        
    }
}