using MediatR;
using Store.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public CreateOrderDto Dto  { get; set; }
        public CreateOrderCommand(CreateOrderDto dto)
        {
            Dto = dto;
        }
    }
}
