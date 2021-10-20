using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class OrderRepository
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
            return await context.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetAllContributorAsync(int contributorId)
        {
            return await context.Orders
                .Where(d => d.Contributor.Id == contributorId)
                .ToListAsync();
        }
        
        public async Task<List<Order>> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Orders
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToListAsync();
        }
    }
}