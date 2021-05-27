using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;

namespace FundRaiser.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly FundRaiserDbContext _db;

        public UserService(FundRaiserDbContext db)
        {
            _db = db;
        }
        public UserOption CreateUser(UserOption userOptions)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserOption GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserOption UpdateUser(int userId, UserOption userOptions)
        {
            throw new NotImplementedException();
        }
    }
}
