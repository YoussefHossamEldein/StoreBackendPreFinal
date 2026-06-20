using MediatR;
using Store.Application.DTOs.Product;
using Store.Application.Features.Products.Queries;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,ProductDto?>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetProductByIdQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return null;
            return new ProductDto
            {
                Stock = product.Stock,
                Category = product.Category,
                Id = product.Id,
                IsAvailable = product.IsAvailable,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
