using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext context;

        public ReviewRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Review> AddAsync(Review review)
        {
            var result = context.Reviews.Add(review);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Review> UpdateAsync(Review review)
        {
            var result = context.Reviews.Update(review);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Review[]> GetAllAsync()
        {
            return await context.Reviews
                .Include(e => e.Contributor)
                .Include(e => e.Entrepreneur)
                .ToArrayAsync();
        }
        
        public async Task<Review> GetAsync(int id)
        {
            return await context.Reviews
                .Include(e => e.Entrepreneur)
                .Include(e => e.Contributor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Review[]> GetAllContributorAsync(int contributorId)
        {
            return await context.Reviews
                .Where(d => d.Contributor.Id == contributorId)
                .ToArrayAsync();
        }
        
        public async Task<Review[]> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Reviews
                .Include(e => e.Contributor)
                .Include(e => e.Entrepreneur)
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToArrayAsync();
        }  
    }
}