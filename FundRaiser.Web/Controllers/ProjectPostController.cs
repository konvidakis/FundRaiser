using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;

namespace FundRaiser.Web.Controllers
{
    public class ProjectPostController : Controller
    {
        private readonly IProjectPostService _projectPostService;

        public ProjectPostController(IProjectPostService projectPostService)
        {
            _projectPostService = projectPostService;
        }
        public IActionResult Create(int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Text,Multimedia,Type,ProjectId")] ProjectPostOption projectPostOption)
        {
            if (ModelState.IsValid)
            {
                _projectPostService.CreateProjectPost(projectPostOption);
                return RedirectToAction("Index", "Projects");
            }
            return View(projectPostOption);
        }
    }
}
