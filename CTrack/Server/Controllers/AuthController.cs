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
    [AllowAnonymous]
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
        public async Task<ActionResult<string>> Login(DTOUserLoginForm request)
        {
            string token = this.userService.Login(request);
            
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register (DTOUserLoginForm request){
            
            userService.RegisterUser(request);

            return Ok();
        }
    }
}