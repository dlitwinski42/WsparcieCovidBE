using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IContributorRepository
    {
        public Task<Contributor> AddAsync(Contributor contributor);
        
        public Task<Contributor> UpdateAsync(Contributor contributor);
        
        public Task<Contributor> GetAsync(int id);

        public Task<Contributor> GetAsync(string login);

        public Task<Contributor[]> GetAllAsync();
    }
}