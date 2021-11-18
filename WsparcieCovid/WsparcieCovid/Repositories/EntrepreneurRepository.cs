using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class EntrepreneurRepository : IEntrepreneurRepository
    {
        private readonly DataContext context;

        public EntrepreneurRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Entrepreneur> AddAsync(Entrepreneur entrepreneur)
        {
            var result = await context.Entrepreneurs.AddAsync(entrepreneur);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Entrepreneur> UpdateAsync(Entrepreneur entrepreneur)
        {
            var result = context.Entrepreneurs.Update(entrepreneur);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Entrepreneur> GetAsync(string login)
        {
            return await context.Entrepreneurs
                .FirstOrDefaultAsync(
                    a => a.User.Id == context.Users
                        .FirstOrDefault(u => u.Username == login).Id);
        }

        public async Task<Entrepreneur[]> GetAllAsync()
        {
            return await context.Entrepreneurs
                .Include(e => e.Address)
                .Include(e => e.SupportMethods)
                .ToArrayAsync();
        }
        
        public async Task<Entrepreneur> GetAsync(int id)
        {
            return await context.Entrepreneurs.FindAsync(id);
        }
    }
}