using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class ProductRepository : IProductRepository
    {

        public readonly DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Product> AddAsync(Product product)
        {
            var result = context.Products.Add(product);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var result = context.Products.Update(product);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products
                .Include(p => p.Entrepreneur)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product[]> GetAllEntrepreneurAsync(int entrepreneurId)
        {
            return await context.Products
                .Where(d => d.Entrepreneur.Id == entrepreneurId)
                .ToArrayAsync();
        }

        public async Task<Product[]> GetAllAsync()
        {
            return await context.Products
                .Include(p => p.Entrepreneur)
                .ToArrayAsync();
        }
    }
}