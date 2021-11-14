using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;

namespace WsparcieCovid.Services
{
    public class OrderService : IOrderService
    {

        private readonly DataContext context;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderProductsRepository orderProductsRepository;
        private readonly IEntrepreneurRepository entrepreneurRepository;
        private readonly IContributorRepository contributorRepository;
        private readonly IProductRepository productRepository;
        
        public OrderService(
            DataContext context,
            IOrderRepository orderRepository,
            IEntrepreneurRepository entrepreneurRepository,
            IContributorRepository contributorRepository,
            IProductRepository productRepository,
            IOrderProductsRepository orderProductsRepository)
        {
            this.context = context;
            this.orderRepository = orderRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
            this.productRepository = productRepository;
            this.orderProductsRepository = orderProductsRepository;
        }
        
        public async Task<IActionResult> CreateAsync(int contributorId, int entrepreneurId)
        {
            var contributor = await contributorRepository.GetAsync(contributorId);
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            
            context.Database?.BeginTransactionAsync();
            var createdOrder = await orderRepository.AddAsync(new Order()
            {
                Contributor = contributor,
                Entrepreneur = entrepreneur,
                DateOrdered = DateTime.Now
            });
            context.Database?.CommitTransactionAsync();
            
            return new JsonResult(createdOrder) {StatusCode = 201};
        }

        public async Task<IActionResult> GetAsync(int id)
        {
            return new JsonResult(await orderRepository.GetAsync(id)) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllAsync()
        {
            return new JsonResult(await orderRepository.GetAllAsync()) {StatusCode = 200};
        }

        public async Task<IActionResult> AddProduct(int orderId, int productId)
        {
            var order = await orderRepository.GetAsync(orderId);
            var product = await productRepository.GetAsync(productId);
            
            context.Database?.BeginTransactionAsync();
            var orderProducts = await orderProductsRepository.AddAsync(new OrderProducts()
            {
               Order = order,
               OrderId = order.Id,
               Product = product,
               ProductId = product.Id
               
            });
            context.Database?.CommitTransactionAsync();
            
            return new JsonResult(orderProducts) {StatusCode = 200};
        }

        public async Task<IActionResult> ChangeStatusAsync(int id, string status)
        {
            var order = await orderRepository.GetAsync(id);
            switch (status)
            {
                case "Paid":
                    order.Status = OrderStatus.Paid;
                    order.DatePaid = DateTime.Now;
                    break;
                case "Received":
                    order.Status = OrderStatus.Received;
                    order.DateReceived = DateTime.Now;
                    break;
            }

            await orderRepository.UpdateAsync(order);
            return new JsonResult(order) {StatusCode = 200};
        }
        
        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return new JsonResult(await orderRepository.GetAllEntrepreneurAsync(entrepreneurId)) {StatusCode = 200};
        }
    }
}