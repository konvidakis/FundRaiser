using FundRaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class UserOption
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //project and transaction is missing

        public UserOption() { }

        public UserOption(User user)
        {
            if (user != null)
            {
                UserId = user.UserId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                
            }
        }
        public User GetUser()
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName =LastName,
                Email = Email,
            };
            return user;
        }
    }
}
