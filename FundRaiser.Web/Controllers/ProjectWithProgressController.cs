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
    public class ProjectWithProgressController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectWithProgressController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public IActionResult ProjectsCreatedByUser()
        {
            List<ProjectOption> projects =
                _projectService.GetProjectsCreatedByUserId(Int32.Parse(HttpContext.Session.GetString("CurrentUser")));
            List<ProjectWithProgressViewModel> projectsWithProgress = ProjectsToProjectsWithProgress(projects);
            return View(projectsWithProgress);
        }


        private List<ProjectWithProgressViewModel> ProjectsToProjectsWithProgress(List<ProjectOption> projects)
        {
            List<ProjectWithProgressViewModel> projectsWithProgress = new List<ProjectWithProgressViewModel>();
            foreach (var project in projects)
            {
                ProjectWithProgressViewModel projectWithProgress = new ProjectWithProgressViewModel()
                {
                    ProjectOption = project,
                    FinancialProgress = _projectService.GetFinancialProgress(project.ProjectId)
                };
                projectsWithProgress.Add(projectWithProgress);
            }

            return projectsWithProgress;
        }
    }
}
