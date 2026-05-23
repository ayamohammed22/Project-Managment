using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Managment.Service.DTOs.User;
using Project_Managment.Service.Interfaces;

namespace Project_Managment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService service;

        public UserController(IAuthService service) 
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
       RegisterDto dto)
        {
            var token =  await service.RegisterAsync(dto);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            var token = await service.LoginAsync(dto);

            return Ok(token);
        }
    }
}
