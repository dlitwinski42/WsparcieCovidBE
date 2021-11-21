using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IDonationRepository
    {
        public Task<Donation> AddAsync(Donation donation);
        
        public Task<Donation> UpdateAsync(Donation donation);
        
        public Task<Donation> GetAsync(int id);

        public Task<bool> CheckIfCodeExists(string donationCode);
        public Task<Donation[]> GetAllContributorAsync(int contributorId);

        public Task<Donation[]> GetAllEntrepreneurAsync(int entrepreneurId);

        public Task<Donation[]> GetAllEntrepreneurWithStatusAsync(int entrepreneurId, string status);
        
        public Task<Donation[]> GetAllContributorWithStatusAsync(int contributorId, string status);
        
        public Task<Donation[]> GetActiveEntrepreneurAsync(int entrepreneurId);

        public Task<Donation[]> GetAllAsync();
    }
}