using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly DataContext context;

        public GiftCardRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<GiftCard> AddAsync(GiftCard giftCard)
        {
            var result = context.GiftCards.Add(giftCard);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<GiftCard> UpdateAsync(GiftCard giftCard)
        {
            var result = context.GiftCards.Update(giftCard);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<GiftCard[]> GetAllAsync()
        {
            return await context.GiftCards.ToArrayAsync();
        }
        
        public async Task<GiftCard> GetAsync(int id)
        {
            return await context.GiftCards.FindAsync(id);
        }

        public async Task<GiftCard[]> GetAllContributorAsync(int contributorId)
        {
            return await context.GiftCards
                .Where(d => d.Contributor.Id == contributorId)
                .ToArrayAsync();
        }
        
        public async Task<GiftCard[]> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.GiftCards
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToArrayAsync();
        }
    }
}