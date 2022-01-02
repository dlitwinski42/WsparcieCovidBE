using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.DTO;
using WsparcieCovid.Entities;
using WsparcieCovid.Services;

namespace WsparcieCovid.Controllers
{
    public class OrdersController
    {
        private readonly IOrderService orderService;

        public OrdersController(
            IOrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpPost("/order")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] OrderDto orderDto)
        {
            return await orderService.CreateAsync(orderDto.ContributorId,orderDto.EntrepreneurId,orderDto.City,orderDto.Street,orderDto.HouseNumber,orderDto.flatNumber);
        }
        
        [HttpGet("/order")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return await orderService.GetAllAsync();
        }
        
        [HttpGet("/order/{id}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await orderService.GetAsync(id));
        }
        
        
        [HttpGet("/order/{id}/paid")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> SetPaidAsync(int id)
        {
            return new JsonResult(await orderService.ChangeStatusAsync(id, "Paid"));
        }
        
        [HttpGet("/order/{orderId}/product/{productId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProductAsync(int orderId, int productId)
        {
            return new JsonResult(await orderService.AddProduct(orderId,productId));
        }
        
        [HttpPost("/order/addProduct")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SerializableError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductAsyncV2([FromBody] AddProductDto addProductDto)
        {
            return await orderService.AddProductAsync(addProductDto.OrderId,addProductDto.ProductId, addProductDto.Amount);
        }
        
        [HttpGet("/order/{id}/recieved")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> SetRecievedAsync(int id)
        {
            return new JsonResult(await orderService.ChangeStatusAsync(id, "Recieved"));
        }
        
        [HttpGet("/order/active/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActiveForEntrepreneur(int entrepreneurId)
        {
            return await orderService.GetActiveForEntrepreneurAsync(entrepreneurId);
        }
        
        
        [HttpGet("/order/delivered/{entrepreneurId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeliveredForEntrepreneur(int entrepreneurId)
        {
            return await orderService.GetDeliveredForEntrepreneurAsync(entrepreneurId);
        }
        
        [HttpGet("/order/history/{contributorId}")]
        [ProducesResponseType(typeof(Donation), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeliveredForContributor(int contributorId)
        {
            return await orderService.GetDeliveredForContributorAsync(contributorId);
        }
    }
}