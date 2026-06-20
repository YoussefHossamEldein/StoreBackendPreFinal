using MediatR;
using Store.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto?>
    {
        public int Id { get; set; }
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
