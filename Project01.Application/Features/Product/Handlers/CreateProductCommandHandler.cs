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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,ProductDto>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public CreateProductCommandHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Stock = request.Dto.Stock,
                Category = request.Dto.Category,
                Name = request.Dto.Name,
                Price = request.Dto.Price,
                IsAvailable = true

            };
            var created = await _productRepository.AddAsync(product);
            return new ProductDto
            {
                Id = created.Id,
                Name = created.Name,
                Stock = created.Stock,
                Price = created.Price,
                Category = created.Category,
                IsAvailable = created.IsAvailable
               
            };
        }
    }
}
