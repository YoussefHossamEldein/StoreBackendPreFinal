using MediatR;
using Store.Application.DTOs.Order;
using Store.Application.Features.Orders.Commands;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGenericRepository<Product> _productRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            IGenericRepository<Product> prodectRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = prodectRepository;
        }
        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Status = "Pending",
                CustomerId = request.Dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()

            };
            decimal total = 0;
            foreach(var item in request.Dto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    continue;
                if (!product.IsAvailable)
                    throw new Exception($"Product {product.Name} is not available and order can not be completed");
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                
                total = product.Price * item.Quantity;
                order.OrderItems.Add(orderItem);

            }
            order.TotalAmount = total;
            var created = await _orderRepository.AddAsync(order);
            return new OrderDto
            {
                Status = created.Status,
                CustomerId = created.CustomerId,
                Id = created.Id,
                OrderDate = created.OrderDate,
                TotalAmount = created.TotalAmount
            };
        }
    }
}
