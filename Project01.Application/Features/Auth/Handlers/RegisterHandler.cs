using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.Application.DTOs.Auth;
using Store.Application.Features.Auth.Commands;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.Auth.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterHandler(IJwtService jwtService,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Dto.Email);
            if (emailExist != null)
                throw new Exception("Email alread exists");
            var user = new AppUser
            {
                FullName = request.Dto.FullName,
                Email = request.Dto.Email,
                UserName = request.Dto.Email
            };
            var created = await _userManager.CreateAsync(user,request.Dto.Password);
            if(!created.Succeeded)
                if (!created.Succeeded)
                    throw new Exception(string.Join(", ", created.Errors.Select(e => e.Description)));

            var role = request.Dto.Role;
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));


            await _userManager.AddToRoleAsync(user, role);
            var token = _jwtService.GenerateToken(user, role);

            return new AuthResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = role,
                Token = token
            };
        }
    }
}
