using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;


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
            if (userOptions == null)
            {
                return null;
            }

            User user = userOptions.GetUser();
            _db.Users.Add(user);
            _db.SaveChanges();
            return new UserOption(user);
        }

        public UserOption GetUserById(int userId)
        {
           
            User user = _db.Users.Find(userId);
            if (user == null) 
            {
                return null;
            }

            return new UserOption(user);
        }

        public UserOption UpdateUser(int userId, UserOption userOptions)
        {
            User dbUser = _db.Users.Find(userId);
            if (dbUser == null)
            {
                return null;
            }
            dbUser.FirstName = userOptions.FirstName;
            dbUser.LastName = userOptions.LastName;
            dbUser.Email = userOptions.Email;
            _db.SaveChanges();
            return new UserOption(dbUser);
        }

        public bool DeleteUser(int userId)
        {
            User dbUser = _db.Users.Find(userId);
            if (dbUser == null)
            {
                return false;
            }
            _db.Users.Remove(dbUser);
            _db.SaveChanges();
            return true;
            
        }
    }
}

    
    

