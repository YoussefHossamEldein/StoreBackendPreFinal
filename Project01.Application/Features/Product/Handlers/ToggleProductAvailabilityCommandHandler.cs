using MediatR;
using Store.Application.Features.Products.Commands;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers
{
    public class ToggleProductAvailabilityCommandHandler : IRequestHandler<ToggleProductAvailabilityCommand,bool>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ToggleProductAvailabilityCommandHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;   
        }

        public async Task<bool> Handle(ToggleProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return false;
            product.IsAvailable = !product.IsAvailable;
            product.UpdatedAt = DateTime.Now;
            return await _productRepository.UpdateAsync(product);
        }
    }
}
