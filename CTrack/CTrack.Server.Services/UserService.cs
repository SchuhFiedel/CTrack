using AutoMapper;
using CTrack.Server.Shared;
using CTrack.Server.Shared.Contracts.Repos;
using CTrack.Server.Shared.Contracts.Services;
using CTrack.Shared.Models.Entities;
using CTrack.Shared.Models.Models;
using CTrack.Shared.Models.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CTrack.Server.Services
{
    public class UserService: IUserService
    {
        protected readonly IPasswordHashService passwordHashService;
        protected readonly IUserRepo userRepo;
        protected readonly IMapper mapper;

        public UserService(IPasswordHashService passwordHashService, IUserRepo userRepo, 
            IMapper mapper)
        {
            this.passwordHashService = passwordHashService;
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        public async void RegisterUser(DTOUserLoginForm request)
        {
            UserModel model = UserModel.StandardUser(new Email(request.Email));
            model.PasswordHash = passwordHashService.Hash(request.Password);
            model.CreatedOn = DateTime.UtcNow;
            model.Id = Guid.NewGuid();

            userRepo.Add(mapper.Map<UserModel, UserEntity>(model));

        }

        //https://www.ais.com/how-to-generate-a-jwt-token-using-net-6/
        public string Login(DTOUserLoginForm request)
        {
            UserModel? model = mapper.Map<UserModel?>(userRepo.GetUserByName(request.Email));
            if (model == null)
                throw new ArgumentException($"User Not Found!");

            if (!passwordHashService.Verify(model.PasswordHash, request.Password))
                throw new ArgumentException($"Wrong Password!");

            string token = CreateToken(model);

            return token;
        }

        public string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email.Value),
                new Claim(ClaimTypes.Role, UserRole.Standard.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                CustomEnvVarService.JWTSecretKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(15),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        
        }

    }
}
