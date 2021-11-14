using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class ProductsController
    {
        private readonly IProductService productService;

        public ProductsController(
            IProductService productService
        )
        {
            this.productService = productService;
        }
        
        [HttpPost("/product")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDto productDto)
        {
            return await productService.CreateAsync(productDto.EntrepreneurId,productDto.Name,productDto.Description,productDto.Price);
        }
        
        [HttpGet("/product/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return await productService.GetAsync(id);
        }
        
        [HttpGet("/product")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await productService.GetAllAsync();
        }

        [HttpGet("/product/entrepreneur/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return await productService.GetAllForEntrepreneurAsync(entrepreneurId);
        }
    }
}