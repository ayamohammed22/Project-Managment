using Microsoft.AspNetCore.Identity;
using Project_Managment.Core.Entities;
using Project_Managment.Infrastructure.Interfaces;
using Project_Managment.Service.DTOs.User;
using Project_Managment.Service.Interfaces;


namespace ProjectManagment.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IJwtProvider _jwtProvider;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtProvider jwtProvider)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _jwtProvider = jwtProvider;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var userByEmail = await _userManager.FindByEmailAsync(dto.Email);
            if(userByEmail is not null)
            {
                throw new Exception("Email is already taken");
            }
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }

            return _jwtProvider.GenerateToken(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null)
            {
                throw new Exception("Invalid credentials");
            }

            var result =  await _signInManager.CheckPasswordSignInAsync(  user, dto.Password,  false);

            if (!result.Succeeded)
            {
                throw new Exception("Invalid credentials");
            }

            return _jwtProvider.GenerateToken(user);
        }

    }
}
