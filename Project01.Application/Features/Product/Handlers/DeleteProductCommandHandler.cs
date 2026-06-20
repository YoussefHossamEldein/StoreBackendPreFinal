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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,bool>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public DeleteProductCommandHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
                return false;
            return  await _productRepository.DeleteAsync(request.Id);
        }
    }
}
