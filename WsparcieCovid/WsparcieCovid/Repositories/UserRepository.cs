using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<User> AddAsync(User user)
        {
            var result = context.Users.Add(user);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<User> UpdateAsync(User user)
        {
            var result = context.Users.Update(user);
            await context.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<User[]> GetAllAsync()
        {
            return await context.Users.ToArrayAsync();
        }
        
        public async Task<User> GetAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> GetAsync(string login)
        {
            return await context.Users.FirstOrDefaultAsync(user => user.Username == login);
        }
    }
}