using MediatR;
using Store.Application.Features.Orders.Commands;
using Store.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Handlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
                return false;
            order.Status = request.Status;
            order.UpdatedAt = DateTime.UtcNow;
            return await _orderRepository.UpdateAsync(order);
        }
    }
}
