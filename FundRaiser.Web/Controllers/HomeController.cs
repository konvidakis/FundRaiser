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
using Microsoft.AspNetCore.Http;

namespace FundRaiser.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

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
            //edw vale session
            HttpContext.Session.SetString("CurrentUser",userOption.UserId+"");
            //auton ton elegxo krata ton gia tin projectsCreatedbyuser
            List<ProjectOption> projects =_projectService.GetProjectsCreatedByUserId(userOption.UserId);
            //ViewBag.UserId = userOption.UserId;
            if (projects.Count>0)
            {
                return RedirectToAction("HomePage", "Projects");
            }
            return RedirectToAction("HomePage", "Projects");
            //return RedirectToAction("HomeFunder", "User", new { @id = userOption.UserId });
        }

    }
}
