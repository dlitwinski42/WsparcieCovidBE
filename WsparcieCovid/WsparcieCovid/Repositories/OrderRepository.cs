using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext context;

        public OrderRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Order> AddAsync(Order order)
        {
            var result = context.Orders.Add(order);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Order> UpdateAsync(Order order)
        {
            var result = context.Orders.Update(order);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Order[]> GetAllAsync()
        {
            return await context.Orders.ToArrayAsync();
        }
        
        public async Task<Order> GetAsync(int id)
        {
            return await context.Orders
                .Include(e => e.Entrepreneur)
                .Include(e => e.Contributor)
                .Include(e => e.OrderProducts)
                .ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Order[]> GetAllContributorAsync(int contributorId)
        {
            return await context.Orders
                .Where(d => d.Contributor.Id == contributorId)
                .ToArrayAsync();
        }
        
        public async Task<Order[]> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Orders
                .Include(e => e.Contributor)
                .Include(e => e.Entrepreneur)
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToArrayAsync();
        }
        
        public async Task<Order[]> GetActiveEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Orders
                .Include(e => e.Contributor)
                .ThenInclude(c => c.User)
                .Include(e => e.Entrepreneur)
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .Where(d => d.Status == OrderStatus.Ordered)
                .ToArrayAsync();
        }
    }
}