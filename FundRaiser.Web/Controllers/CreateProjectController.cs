using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Web.Models;
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
        public IActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProjectViewModel createProjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createProjectViewModel);
            }

            ProjectOption projectCreated= _projectService.CreateProject(createProjectViewModel.ProjectOption);
            foreach (var rewardOption in createProjectViewModel.RewardOptions)
            {
                rewardOption.ProjectId = projectCreated.ProjectId;
                _rewardService.CreateReward(rewardOption);
            }
            return RedirectToAction("Index", "Projects");
        }

    }
}
