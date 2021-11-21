using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext context;
        
        public AddressRepository(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<Address> AddAsync(Address address)
        {
            var result = context.Addresses.Add(address);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Address> UpdateAsync(Address supportMethods)
        {
            var result = context.Addresses.Update(supportMethods);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Address> GetAsync(int id)
        {
            return await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Address[]> GetAllAsync()
        {
            return await context.Addresses.ToArrayAsync();
        }
    }
}