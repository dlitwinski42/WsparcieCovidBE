using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DataContext context;

        public DonationRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Donation> AddAsync(Donation donation)
        {
            var result = context.Donations.Add(donation);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Donation> UpdateAsync(Donation donation)
        {
            var result = context.Donations.Update(donation);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<Donation[]> GetAllContributorWithStatusAsync(int contributorId, string status)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Donation[]> GetAllAsync()
        {
            return await context.Donations.ToArrayAsync();
        }
        
        public async Task<Donation> GetAsync(int id)
        {
            return await context.Donations.FindAsync(id);
        }

        Task<Donation[]> IDonationRepository.GetAllContributorAsync(int contributorId)
        {
            throw new System.NotImplementedException();
        }

        Task<Donation[]> IDonationRepository.GetAllEntrepreneurAsync(int entrepreneurId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Donation[]> GetAllEntrepreneurWithStatusAsync(int entrepreneurId, string status)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Donation>> GetAllContributorAsync(int contributorId)
        {
            return await context.Donations
                .Where(d => d.Contributor.Id == contributorId)
                .ToListAsync();
        }
        
        public async Task<List<Donation>> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Donations
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToListAsync();
        }
    }
}