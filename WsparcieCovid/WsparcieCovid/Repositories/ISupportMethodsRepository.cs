using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface ISupportMethodsRepository
    {
        public Task<SupportMethods> AddAsync(SupportMethods supportMethods);
        
        public Task<SupportMethods> UpdateAsync(SupportMethods supportMethods);
        
        public Task<SupportMethods> GetAsync(int id);
        
        public Task<SupportMethods[]> GetAllAsync();
    }
}