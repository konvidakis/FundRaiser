﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundRaiser.Database;
using FundRaiser.Model;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Service.Implementations;

namespace FundRaiser.Web.Controllers
{
    public class ProjectsController : Controller
    {
        public IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
            
        }

        // GET: Projects
        public  IActionResult Index()
        {
            List<ProjectOption> projectOptions = _projectService.ProjectToProjectOptions(_projectService.GetAllProjects());
            return View(projectOptions);
        }

        // GET: Projects/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetProjectById((int)id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
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
        public IActionResult Create([Bind("ProjectId,Category,Title,Logo,TimeStamp,Description,SetGoal,AmountPledged,StartDate,EndDate")] ProjectOption projectOption)
        {
            if (ModelState.IsValid)
            {
                _projectService.CreateProject(projectOption);
                return RedirectToAction(nameof(Index));
            }
            return View(projectOption);
        }

        // GET: Projects/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetProjectById((int) id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProjectId,Category,Title,Logo,TimeStamp,Description,SetGoal,AmountPledged,StartDate,EndDate")] ProjectOption projectOption)
        {
            if (id != projectOption.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _projectService.UpdateProject(id, projectOption);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectOption.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projectOption);
        }

        // GET: Projects/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _projectService.GetProjectById((int)id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectService.DeleteProject(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return false;
            }
            return true;
        }
    }
}
