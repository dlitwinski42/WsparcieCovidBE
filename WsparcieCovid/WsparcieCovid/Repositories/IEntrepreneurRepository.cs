using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IEntrepreneurRepository
    {
        public Task<Entrepreneur> AddAsync(Entrepreneur entrepreneur);
        
        public Task<Entrepreneur> UpdateAsync(Entrepreneur entrepreneur);
        
        public Task<Entrepreneur> GetAsync(int id);

        public Task<Entrepreneur> GetAsync(string login);

        public Task<Entrepreneur[]> GetAllAsync();
    }
}