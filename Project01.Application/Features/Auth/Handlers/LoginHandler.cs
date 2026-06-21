using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Application.DTOs.Auth;
using Store.Application.Features.Auth.Commands;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Auth.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto?>
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<AppUser> _userManager;
        public LoginHandler(IJwtService jwtService,UserManager<AppUser> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }
        public async Task<AuthResponseDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userExisting = await _userManager.FindByEmailAsync(request.Dto.Email);
            if (userExisting == null)
                return null;
            var isValid = await _userManager.CheckPasswordAsync(userExisting,request.Dto.Password);
            if (!isValid)
                return null;
            var roles = await _userManager.GetRolesAsync(userExisting);
            var role = roles.FirstOrDefault() ?? "User";
            var token =  _jwtService.GenerateToken(userExisting, role);
            return new AuthResponseDto
            {
                Email = userExisting.Email!,
                FullName = userExisting.FullName,
                Id = userExisting.Id,
                Role = role,
                Token = token
            };

        }
    }
}
