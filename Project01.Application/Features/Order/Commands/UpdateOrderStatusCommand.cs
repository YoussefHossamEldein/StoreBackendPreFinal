using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Orders.Commands
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public UpdateOrderStatusCommand(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
