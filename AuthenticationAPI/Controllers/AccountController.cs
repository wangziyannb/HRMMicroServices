using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Models;
using JWTAuthenticationManager;
using JWTAuthenticationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler jwtTokenHandler;
        private readonly IAuthenticationService service;

        public AccountController(JwtTokenHandler jwtTokenHandler, IAuthenticationService service)
        {
            this.jwtTokenHandler = jwtTokenHandler;
            this.service = service;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await service.SignInAsync(model);
            if (result.Succeeded)
            {
                AuthenticationRequest request = new AuthenticationRequest()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                var response = jwtTokenHandler.GenerateToken(request, "admin");
                if (response == null)
                {
                    return Unauthorized();
                }
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await service.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok("Your account has been created");
            }
            return BadRequest();
        }

    }
}
