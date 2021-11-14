using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext context;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IProductRepository productRepository;
        
        public ProductService(
            DataContext context,
            IEntrepreneurRepository entrepreneurRepository,
            IProductRepository productRepository)
        {
            this.context = context;
            this.entrepreneurRepository = entrepreneurRepository;
            this.productRepository = productRepository;
        }
        
        public async Task<IActionResult> CreateAsync(int entrepreneurId, string name, string description, float price)
        {
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            context.Database?.BeginTransactionAsync();
            var createdProduct = await productRepository.AddAsync(new Product()
            {
                Entrepreneur = entrepreneur,
                Name = name,
                Description = description,
                Price = price
            });
            context.Database?.CommitTransactionAsync();
            return new JsonResult(createdProduct) {StatusCode = 201};
        }

        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await productRepository.GetAsync(id)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await productRepository.GetAllAsync()) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return new JsonResult(await productRepository.GetAllEntrepreneurAsync(entrepreneurId)) {StatusCode = 200};
        }
    }
}