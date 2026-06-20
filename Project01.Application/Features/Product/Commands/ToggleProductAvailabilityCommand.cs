using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Commands
{
    public class ToggleProductAvailabilityCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ToggleProductAvailabilityCommand(int id)
        {
            Id = id;
        }
    }
}
