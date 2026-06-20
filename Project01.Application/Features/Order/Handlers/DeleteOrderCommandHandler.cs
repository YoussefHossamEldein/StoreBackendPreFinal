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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
                return false;
            return await _orderRepository.DeleteAsync(request.Id);
        }
    }
}
