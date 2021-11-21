using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WsparcieCovid.Data;
using WsparcieCovid.DTO;
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
        private readonly IAddressRepository addressRepository;
        
        public OrderService(
            DataContext context,
            IOrderRepository orderRepository,
            IAddressRepository addressRepository,
            IEntrepreneurRepository entrepreneurRepository,
            IContributorRepository contributorRepository,
            IProductRepository productRepository,
            IOrderProductsRepository orderProductsRepository)
        {
            this.context = context;
            this.orderRepository = orderRepository;
            this.addressRepository = addressRepository;
            this.contributorRepository = contributorRepository;
            this.entrepreneurRepository = entrepreneurRepository;
            this.productRepository = productRepository;
            this.orderProductsRepository = orderProductsRepository;
        }
        
        public async Task<IActionResult> CreateAsync(
            int contributorId,
            int entrepreneurId,
            string? city,
            string? street,
            string? houseNumber,
            string? flatNumber
            )
        {
            var contributor = await contributorRepository.GetAsync(contributorId);
            var entrepreneur = await entrepreneurRepository.GetAsync(entrepreneurId);
            Address address;
            if (contributor.Address == null)
            {
                if (city != null && street != null && houseNumber != null && flatNumber != null)
                {
                    address = await addressRepository.AddAsync(new Address()
                    {
                        City = city,
                        FlatNumber = flatNumber,
                        HouseNumber = houseNumber,
                        Street = street
                    });
                }
                else
                {
                    return new JsonResult(new ExceptionDto {Message = "Address needed"}) {StatusCode = 400};
                }
            }else
            {
                address = contributor.Address;
            }
            
            context.Database?.BeginTransactionAsync();
            var createdOrder = await orderRepository.AddAsync(new Order()
            {
                Contributor = contributor,
                Entrepreneur = entrepreneur,
                DateOrdered = DateTime.Now,
                Status = OrderStatus.Ordered,
                Address = address
                
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
                case "Received":
                    order.Status = OrderStatus.Received;
                    order.DateReceived = DateTime.Now;
                    break;
            }

            await orderRepository.UpdateAsync(order);
            return new JsonResult(order) {StatusCode = 200};
        }

        public async Task<IActionResult> AddProductAsync(int orderId, int productId, int amount)
        {
            var order = await orderRepository.GetAsync(orderId);
            var product = await productRepository.GetAsync(productId);
            
            context.Database?.BeginTransactionAsync();
            var orderProducts = await orderProductsRepository.AddAsync(new OrderProducts()
            {
                Order = order,
                OrderId = order.Id,
                Product = product,
                ProductId = product.Id,
                Amount = amount
               
            });
            context.Database?.CommitTransactionAsync();
            
            return new JsonResult(orderProducts) {StatusCode = 200};
        }

        public async Task<IActionResult> GetAllForEntrepreneurAsync(int entrepreneurId)
        {
            return new JsonResult(await orderRepository.GetAllEntrepreneurAsync(entrepreneurId)) {StatusCode = 200};
        }
        
        public async Task<IActionResult> GetActiveForEntrepreneurAsync(int entrepreneurId)
        {
            var orders = await orderRepository.GetActiveEntrepreneurAsync(entrepreneurId);
            foreach(var order in orders)
            {
                order.Contributor.User.Email = null;
                order.Contributor.User.Username = null;
                order.Contributor.User.PassHash = null;
            }
            return new JsonResult(orders) {StatusCode = 200};
        }
    }
}