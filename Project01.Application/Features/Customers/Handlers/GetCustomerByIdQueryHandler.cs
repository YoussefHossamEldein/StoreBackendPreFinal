using MediatR;
using Store.Application.DTOs.Customer;
using Store.Application.Features.Customers.Queries;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery,CustomerDto?>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        public GetCustomerByIdQueryHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                return null;
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name
            };
        }
    }
}
