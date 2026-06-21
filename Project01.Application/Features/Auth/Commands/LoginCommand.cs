using MediatR;
using Store.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<AuthResponseDto?>
    {
        public LoginDto Dto { get; set; }
        public LoginCommand(LoginDto dto)
        {
            Dto = dto;
        }
    }
}
