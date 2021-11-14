using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class SupportMethodsRepository : ISupportMethodsRepository
    {
        private readonly DataContext context;
        
        public SupportMethodsRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<SupportMethods> AddAsync(SupportMethods supportMethods)
        {
            var result = context.SupportMethods.Add(supportMethods);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<SupportMethods> UpdateAsync(SupportMethods supportMethods)
        {
            var result = context.SupportMethods.Update(supportMethods);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<SupportMethods> GetAsync(int id)
        {
            return await context.SupportMethods.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SupportMethods[]> GetAllAsync()
        {
            return await context.SupportMethods.ToArrayAsync();
        }
    }
}