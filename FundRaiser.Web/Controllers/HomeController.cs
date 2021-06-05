using FundRaiser.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;

namespace FundRaiser.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public IActionResult Login(string email)
        {
            UserOption userOption=_userService.GetUserByEmail(email);
            //if ... _projectService.GetProjectsByUserId() an ayti i lista den einai keni
            if (email.Equals("Email"))
            {
                return View("Index"); //gurna sto View tou Creator me parametro userOption.userId
            }
            else
            {
                return View(); //gurna sto View tou Funder me parametro userOption.userId
            }
            //an den vreis ton user useroption== null tote return View()
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
