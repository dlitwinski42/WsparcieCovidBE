using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IAddressRepository
    {
        public Task<Address> AddAsync(Address address);
        
        public Task<Address> UpdateAsync(Address address);
        
        public Task<Address> GetAsync(int id);
        
        public Task<Address[]> GetAllAsync();
    }
}