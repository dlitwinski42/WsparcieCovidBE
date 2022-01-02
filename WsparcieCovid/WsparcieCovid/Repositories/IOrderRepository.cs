using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IOrderRepository
    {
         public Task<Order> AddAsync(Order order);
                
         public Task<Order> UpdateAsync(Order order);
                
         public Task<Order> GetAsync(int id);
        
         public Task<Order[]> GetAllContributorAsync(int contributorId);
        
         public Task<Order[]> GetAllEntrepreneurAsync(int entrepreneurId);
        
         public Task<Order[]> GetAllAsync();

         public  Task<Order[]> GetActiveEntrepreneurAsync(int entrepreneurId);
         
         public  Task<Order[]> GetDeliveredEntrepreneurAsync(int entrepreneurId);
         
         public  Task<Order[]> GetDeliveredContributorAsync(int contributorId);
    }
}