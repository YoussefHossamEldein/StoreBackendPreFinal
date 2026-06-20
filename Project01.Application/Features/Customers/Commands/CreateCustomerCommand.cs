using MediatR;
using Store.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public CreateCustomerDto Dto { get; set; }
        public CreateCustomerCommand(CreateCustomerDto dto)
        {
            Dto = dto;
        }
    }
}
