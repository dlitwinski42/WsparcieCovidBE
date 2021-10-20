using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IReviewRepository
    {
         public Task<Review> AddAsync(Review review);
                
         public Task<Review> UpdateAsync(Review review);
                
         public Task<Review> GetAsync(int id);
        
         public Task<Review[]> GetAllContributorAsync(int contributorId);
        
         public Task<Review[]> GetAllEntrepreneurAsync(int entrepreneurId);
        
         public Task<Review[]> GetAllAsync();
    }
}