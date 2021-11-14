using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IOrderProductsRepository
    {
        public Task<OrderProducts> AddAsync(OrderProducts orderProducts);
                
        public Task<OrderProducts> UpdateAsync(OrderProducts orderProducts);
                
        public Task<OrderProducts> GetAsync(int id);

        public Task<OrderProducts[]> GetAllOrderAsync(int orderId);
        
        public Task<OrderProducts[]> GetAllAsync();
    }
}