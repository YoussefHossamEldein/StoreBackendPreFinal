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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery,List<ProductDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            if (products == null)
                return [];
            var productList = products.Select(s => new ProductDto
            {
                Stock = s.Stock,
                Category = s.Category,
                Id = s.Id,
                IsAvailable = s.IsAvailable,
                Name = s.Name,
                Price = s.Price
            }).ToList();
            return productList;
        }
    }
}
