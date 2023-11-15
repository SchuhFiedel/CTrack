using CTrack.Shared.Models.Models;
using CTrack.Shared.Models.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrack.Server.Shared.Contracts.Services
{
    public interface IUserService
    {
        public string Login(UserLoginDTO request);
        public UserModel RegisterUser(UserLoginDTO request);
        
    }
}
