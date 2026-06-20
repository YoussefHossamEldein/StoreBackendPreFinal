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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,List<CustomerDto>>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        public GetAllCustomersQueryHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);
            var customersDto = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return customersDto;
        }
    }
}
