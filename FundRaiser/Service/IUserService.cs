using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
   public interface IUserService
    {
        public UserOption CreateUser(UserOption userOptions);

        public UserOption GetUserById(int userId);

        public UserOption UpdateUser(int userId, UserOption userOptions);

        public bool DeleteUser(int userId);

        public UserOption GetUserByEmail(string email);

    }
}
