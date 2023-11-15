using CTrack.Server.Services;
using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Server.Shared.Contracts.Services;
using CTrack.Shared.Models.Models;
using CTrack.Shared.Models.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CTrack.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IUserService userService;

        public AuthController(ILogger<AuthController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {
            string token = this.userService.Login(request);
            //string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVG9ueSBTdGFyayIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6Iklyb24gTWFuIiwiZXhwIjozMTY4NTQwMDAwfQ.IbVQa1lNYYOzwso69xYfsMOHnQfO3VLvVqV2SOXS7sTtyyZ8DEf5jmmwz2FGLJJvZnQKZuieHnmHkg7CGkDbvA";
            
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserModel>> Register (UserLoginDTO request){
            UserModel user = userService.RegisterUser(request);
            user.Email = new Email(request.Email);

            return Ok(user);
        }
    }
}