using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IGiftCardRepository
    {
        public Task<GiftCard> AddAsync(GiftCard giftCard);
        
        public Task<GiftCard> UpdateAsync(GiftCard giftCard);
        
        public Task<GiftCard> GetAsync(int id);

        public Task<GiftCard[]> GetAllContributorAsync(int contributorId);

        public Task<GiftCard[]> GetAllEntrepreneurAsync(int entrepreneurId);

        public Task<GiftCard[]> GetAllAsync();
    }
}