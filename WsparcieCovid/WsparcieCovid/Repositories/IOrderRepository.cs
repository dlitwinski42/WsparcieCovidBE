using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IOrderRepository
    {
         public Task<Donation> AddAsync(Order order);
                
         public Task<Donation> UpdateAsync(Order order);
                
         public Task<Donation> GetAsync(int id);
        
         public Task<Donation[]> GetAllContributorAsync(int contributorId);
        
         public Task<Donation[]> GetAllEntrepreneurAsync(int entrepreneurId);
        
         public Task<Donation[]> GetAllAsync();
    }
}