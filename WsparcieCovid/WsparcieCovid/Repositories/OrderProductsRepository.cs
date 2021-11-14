using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class OrderProductsRepository : IOrderProductsRepository
    {
        public readonly DataContext context;

        public OrderProductsRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<OrderProducts> AddAsync(OrderProducts orderProducts)
        {
            var result = context.OrderProducts.Add(orderProducts);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<OrderProducts> UpdateAsync(OrderProducts orderProducts)
        {
            var result = context.OrderProducts.Update(orderProducts);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<OrderProducts> GetAsync(int id)
        {
            return await context.OrderProducts
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<OrderProducts[]> GetAllOrderAsync(int orderId)
        {
            return await context.OrderProducts
                .Where(d => d.Order.Id == orderId)
                .ToArrayAsync();
        }

        public async Task<OrderProducts[]> GetAllAsync()
        {
            return await context.OrderProducts
                .ToArrayAsync();
        }
    }
}