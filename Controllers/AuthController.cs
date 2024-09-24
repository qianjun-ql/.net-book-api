

using BookServicesApi.DTOs;
using BookServicesApi.Models;
using BookServicesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookServicesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase {
        private readonly AuthService _authService;
        
        public AuthController(AuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model) {
            if (ModelState.IsValid) {
                var user = new User {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    Province = model.Province,
                    ZipCode = model.ZipCode,
                    Phone = model.Phone
                };

                var result = await _authService.RegisterUserAsync(user, model.Password);
                if (result.Succeeded) {
                    return Ok(new {Message = "User registered successfully"});
                } 
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _authService.FindUserByEmailAsync(model.Email);
            if (user == null | !await _authService.CheckPasswordAsync(user,model.Password)) {
                return Unauthorized(new {Message = "Invalid email or password"});
            }

            var token = _authService.GenerateJwtToken(user);

            return Ok(new {Token = token});

        }
    }

}