using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrack.Server.Contracts.Services
{
    public interface IPasswordHashService
    {
        public string Hash(string pw);
        public bool Verify(string passwordHash, string inputPassword);
    }
}
