using MediatR;
using Store.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<AuthResponseDto>
    {
        public RegisterDto Dto { get; set; }
        public RegisterCommand(RegisterDto dto)
        {
            Dto = dto;
        }
    }
}
