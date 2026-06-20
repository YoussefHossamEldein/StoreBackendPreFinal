using MediatR;
using Store.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
