using MediatR;
using Store.Application.DTOs.Product;
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
    public class UpdateProductCommandHandler  : IRequestHandler<UpdateProductCommand,bool>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public UpdateProductCommandHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return false;
            product.Price = request.Dto.Price;
            product.Stock = request.Dto.Stock;
            product.Name = request.Dto.Name;
            product.Category = request.Dto.Category;
            await _productRepository.UpdateAsync(product);
            return true;
        }
    }
}
