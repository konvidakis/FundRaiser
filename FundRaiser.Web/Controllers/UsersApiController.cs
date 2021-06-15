using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FundRaiser.Model;
using FundRaiser.Options;
using FundRaiser.Service;

// have not implemented the front-end. This is a demo for testing APIs functionality
namespace FundRaiser.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/UsersApi
        [HttpGet]
        public ActionResult<IEnumerable<UserOption>> GetUsers()
        {
            return _userService.GetUsers();
        }

        // GET: api/UsersApi/5
        [HttpGet("{id}")]
        public  ActionResult<UserOption> GetUser(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/UsersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserOption userOption)
        {
            if (id != userOption.UserId)
            {
                return BadRequest();
            }
            if (!UserExists(id))
            {
                return NotFound();
            }
            _userService.UpdateUser(id, userOption);
            return NoContent();
        }

        // POST: api/UsersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<User> PostUser(UserOption userOption)
        {
            _userService.CreateUser(userOption);

            return CreatedAtAction("GetUser", new { id = userOption.UserId }, userOption);
        }

        // DELETE: api/UsersApi/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteUser(int id)
        {
            var userOption = _userService.GetUserById(id);
            if (userOption == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(userOption.UserId);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            var userOption=_userService.GetUserById(id);
            if (userOption == null)
            {
                return false;
            }

            return true;
        }
    }
}
