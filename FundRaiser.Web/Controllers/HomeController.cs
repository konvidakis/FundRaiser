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
        private readonly IProjectService _projectService;

        public HomeController(ILogger<HomeController> logger,IUserService userService,IProjectService projectService)
        {
            _logger = logger;
            _userService = userService;
            _projectService = projectService;
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
        public IActionResult Index(string email)
        {
            UserOption userOption=_userService.GetUserByEmail(email);
            if (userOption == null)
            {
                return View("Index");
            }
            List<ProjectOption> projects =_projectService.GetProjectsCreatedByUserId(userOption.UserId);
            ViewBag.UserId = userOption.UserId;
            if (projects.Count>0)
            {
                return RedirectToAction("HomeCreator", "User", new { @id = userOption.UserId });
            }
            return RedirectToAction("HomeFunder", "User", new { @id = userOption.UserId });
        }
    }
}
