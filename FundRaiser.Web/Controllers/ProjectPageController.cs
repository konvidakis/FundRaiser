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
    public class ProjectPageController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IRewardService _rewardService;
        private readonly IProjectPostService _projectPostService;
        private readonly ITransactionService _transactionService;

        public ProjectPageController(IProjectService projectService, IRewardService rewardService, IProjectPostService projectPostService, ITransactionService transactionService)
        {
            _projectService = projectService;
            _projectPostService = projectPostService;
            _rewardService = rewardService;
            _transactionService = transactionService;
        }
        public IActionResult Details(int id)
        {

            ProjectPageViewModel projectPage = new ProjectPageViewModel();
            projectPage.ProjectOption = _projectService.GetProjectById(id);
            if (projectPage.ProjectOption == null)
            {
                return NotFound();
            }

            projectPage.RewardOptions = _rewardService.GetRewardsByProjectId(id);
            projectPage.ProjectPostOptions = _projectPostService.GetAllProjectPosts(id);

            return View(projectPage);
        }

        public IActionResult FundProject(int rewardId, int projectId, decimal amount)
        {
            RewardOption rewardOption = _rewardService.GetRewardById(rewardId);
            TransactionOption transactionOption = new TransactionOption()
            {
                Amount = rewardOption.AmountRequired,
                RewardId = rewardId,
                ProjectId = projectId,
                UserId = Int32.Parse(HttpContext.Session.GetString("CurrentUser"))
            };
            _transactionService.CreateTransaction(transactionOption);

            return RedirectToAction("Index", "Projects");
        }
    }
}
