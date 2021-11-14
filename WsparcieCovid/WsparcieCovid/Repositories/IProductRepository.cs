using System.Threading.Tasks;
using WsparcieCovid.Entities;

namespace WsparcieCovid.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> AddAsync(Product product);
                
        public Task<Product> UpdateAsync(Product product);
                
        public Task<Product> GetAsync(int id);

        public Task<Product[]> GetAllEntrepreneurAsync(int entrepreneurId);
        
        public Task<Product[]> GetAllAsync();
    }
}