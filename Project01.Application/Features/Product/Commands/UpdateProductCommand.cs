using MediatR;
using Store.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateProductDto  Dto    { get; set; }
        public UpdateProductCommand(int id, UpdateProductDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
