using MediatR;
using Store.Application.DTOs.Customer;
using Store.Application.Features.Customers.Commands;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        public CreateCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Dto.Name
            };
           var created =  await _customerRepository.AddAsync(customer);
            return new CustomerDto
            {
                Id = created.Id,
                Name = created.Name
            };
        }
    }
}
