using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiser.Web.Controllers
{
    public class CreateProjectController : Controller
    {
        public IProjectService _projectService;
        public IRewardService _rewardService;

        public CreateProjectController(IProjectService projectService,IRewardService rewardService)
        {
            _projectService = projectService;
            _rewardService = rewardService;
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]CreateProjectViewModel createProjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createProjectViewModel);
            }
            //add userId
            createProjectViewModel.ProjectOption.UserId= Int32.Parse(HttpContext.Session.GetString("CurrentUser"));
            //add Logo
            var x = createProjectViewModel.ProjectImage.FileName;
            var uniqueFileName = GetUniqueFileName(createProjectViewModel.ProjectImage.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\logo", uniqueFileName);

            createProjectViewModel.ProjectImage.CopyTo(new FileStream(filePath, FileMode.Create));
            createProjectViewModel.ProjectOption.Logo = uniqueFileName;
            //add Project
            ProjectOption projectCreated= _projectService.CreateProject(createProjectViewModel.ProjectOption);
            //add rewards
            foreach (var rewardOption in createProjectViewModel.RewardOptions)
            {
                rewardOption.ProjectId = projectCreated.ProjectId;
                _rewardService.CreateReward(rewardOption);
            }
            return RedirectToAction("Index", "Projects");
        }

        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

    }
}
