using MediatR;
using Store.Application.DTOs.Order;
using Store.Application.Features.Orders.Queries;
using Store.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery,List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrdersWithCustomerAndOrderItemsAsync(cancellationToken);
            if (orders == null)
                return [];
            var orderList = orders.Select(o => new OrderDto
            {
                Status = o.Status,
                CustomerId = o.CustomerId,
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                OrderDate = o.OrderDate,
                Items = o.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()        
            }).ToList();
            return orderList;
        }
    }
}
