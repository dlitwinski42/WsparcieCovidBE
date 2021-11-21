using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly DataContext context;
        private readonly IGiftCardRepository giftCardRepository;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IContributorRepository contributorRepository;
        
        public GiftCardService(
            DataContext context,
            IGiftCardRepository giftCardRepository,
            IEntrepreneurRepository entrepreneurRepository,
            IContributorRepository contributorRepository)
        {
            this.context = context;
            this.giftCardRepository = giftCardRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
        }
        
        public async Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId)
        {
            var contributor = await contributorRepository.GetAsync(contributorId);
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            string code = "";
            
            code = Path.GetRandomFileName();
            code = code.Replace(".", "");
            code = code.Substring(0, 8);

                while (await giftCardRepository.CheckIfCodeExists(code))
                {
                    code = Path.GetRandomFileName();
                    code = code.Replace(".", "");
                    code = code.Substring(0, 8);
                }

                context.Database?.BeginTransactionAsync();
            var createdReview = await giftCardRepository.AddAsync(new GiftCard
            {
                Contributor = contributor,
                Entrepreneur = entrepreneur,
                Status = GiftCardStatus.Ordered,
                TimeOrdered = DateTime.Now,
                RedeemCode = code
            });
            
            context.Database?.CommitTransactionAsync();

            return new JsonResult(createdReview) {StatusCode = 201};
        }

        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await giftCardRepository.GetAsync(id)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAsync(string redeemCode)
        {
            return new JsonResult(await giftCardRepository.GetAsync(redeemCode)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await giftCardRepository.GetAllAsync()) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return new JsonResult(await giftCardRepository.GetAllEntrepreneurAsync(entrepreneurId)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForContributorAsync(int contributorId)
        {
            return new JsonResult(await giftCardRepository.GetAllContributorAsync(contributorId)) {StatusCode = 200};
        }

        public async Task<IActionResult> SetStatusAsync(int id, string status)
        {
            var giftCard = await giftCardRepository.GetAsync(id);
            switch (status)
            {
                case "Paid":
                    giftCard.Status = GiftCardStatus.Paid;
                    giftCard.TimePaid = DateTime.Now;
                    break;
                case "Used":
                    giftCard.Status = GiftCardStatus.Used;
                    giftCard.TimeUsed = DateTime.Now;
                    break;
            }

            await giftCardRepository.UpdateAsync(giftCard);
            return new JsonResult(giftCard) {StatusCode = 200};

        }
        
        public async Task<IActionResult> GetActiveForEntrepreneurAsync(int entrepreneurId)
        {
            var giftcards = await giftCardRepository.GetActiveEntrepreneurAsync(entrepreneurId);
            foreach(var giftcard in giftcards)
            {
                giftcard.Contributor.User.Email = null;
                giftcard.Contributor.User.Username = null;
                giftcard.Contributor.User.PassHash = null;
            }
            return new JsonResult(giftcards) {StatusCode = 200};
        }
        
        public async Task<IActionResult> GetAvailableForEntrepreneurAsync(int entrepreneurId)
        {
            var giftcards = await giftCardRepository.GetAvailableEntrepreneurAsync(entrepreneurId);
            foreach(var giftcard in giftcards)
            {
                giftcard.Contributor.User.Email = null;
                giftcard.Contributor.User.Username = null;
                giftcard.Contributor.User.PassHash = null;
            }
            return new JsonResult(giftcards) {StatusCode = 200};
        }
    }
}