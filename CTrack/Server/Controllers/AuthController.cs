using CTrack.Server.Contracts;
using CTrack.Server.Contracts.Services;
using CTrack.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CTrack.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ICTrackContext cTrackContext; 

        public AuthController(ILogger<AuthController> logger, ICTrackContext cTrackContext)
        {
            _logger = logger;
            this.cTrackContext = cTrackContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public Task<UserModel> Login(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}