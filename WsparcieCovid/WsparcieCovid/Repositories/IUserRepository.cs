using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<User> GetAsync(int id);
        public Task<User> GetAsync(string login);
        public Task<User[]> GetAllAsync();
    }
}