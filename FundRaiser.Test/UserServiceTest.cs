using System;
using FundRaiser.Database;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Service.Implementations;
using Xunit;

namespace FundRaiser.Test
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userService = new UserService(new FundRaiserDbContext());
        }
        [Fact]
        public void CreateUpdateAndDeleteUserTest()
        {
            UserOption userOption = new UserOption()
            {
                FirstName = "Giorgos",
                LastName = "Papadopoulos",
                Email = "gpapado@gmail.com"
            };
            Assert.True(userOption.UserId==0,"The userOption has not been saved");
            
            userOption = _userService.CreateUser(userOption);
            Assert.True(userOption.UserId>0, "The userOption has been saved");

            userOption.FirstName = "Kostas";
            userOption = _userService.UpdateUser(userOption.UserId, userOption);
            Assert.True(String.Equals(userOption.FirstName,"Kostas"),"The user first name has changed");

            bool deleteResult = _userService.DeleteUser(userOption.UserId);
            Assert.True(deleteResult,"The User has been deleted");
        }

        [Fact]
        public void GetUserTest()
        { 
            //User with id 1 always will exist in the database
            UserOption userOption = _userService.GetUserById(1);
            Assert.True(userOption!=null,"A user has returned");
        }
    }
}
