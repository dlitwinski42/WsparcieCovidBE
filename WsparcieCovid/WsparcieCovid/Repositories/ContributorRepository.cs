using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    
    
    public class ContributorRepository : IContributorRepository
    {
        private readonly DataContext context;

        public ContributorRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Contributor> AddAsync(Contributor contributor)
        {
            var result = context.Contributors.Add(contributor);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Contributor> UpdateAsync(Contributor contributor)
        {
            var result = context.Contributors.Update(contributor);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Contributor> GetAsync(string login)
        {
            return await context.Contributors
                .FirstOrDefaultAsync(
                    a => a.User.Id == context.Users
                        .FirstOrDefault(u => u.Username == login).Id);
        }

        public async Task<Contributor[]> GetAllAsync()
        {
            return await context.Contributors.ToArrayAsync();
        }
        
        public async Task<Contributor> GetAsync(int id)
        {
            return await context.Contributors.FindAsync(id);
        }

    }
}