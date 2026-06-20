using MediatR;
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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,bool>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        public DeleteCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                return false;
            await _customerRepository.DeleteAsync(request.Id);
            return true;

        }
    }
}
