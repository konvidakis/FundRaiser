using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Web.Models;
using Microsoft.AspNetCore.Http;

namespace FundRaiser.Web.Controllers
{
    public class ProjectsInvestedController : Controller
    {
        private readonly IRewardService _rewardService;
        private readonly IProjectService _projectService;


        public ProjectsInvestedController(IRewardService rewardService, IProjectService projectService)
        {
            _projectService = projectService;
            _rewardService = rewardService;
        }

        public IActionResult ProjectsInvestedByUser()
        {
            List<ProjectsInvestedViewModel> projectsInvested = new List<ProjectsInvestedViewModel>();
            List<RewardOption> rewards = _rewardService.GetRewardsByUserId(Int32.Parse(HttpContext.Session.GetString("CurrentUser")));
            foreach (var reward in rewards)
            {
                ProjectsInvestedViewModel projectInvested = new ProjectsInvestedViewModel();
                projectInvested.RewardOption = reward;
                projectInvested.ProjectOption = _projectService.GetProjectById(reward.ProjectId);
                projectInvested.FinancialProgress = _projectService.GetFinancialProgress(reward.ProjectId);
                projectsInvested.Add(projectInvested);
            }
            return View(projectsInvested);
            //return View(_projectService.GetProjectsInvestedByUserId(Int32.Parse(HttpContext.Session.GetString("CurrentUser"))));
        }
    }
}
