using MediatR;
using Store.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public CreateProductDto Dto { get; set; }
        public CreateProductCommand(CreateProductDto dto)
        {
            Dto = dto;
        }
    }
}
