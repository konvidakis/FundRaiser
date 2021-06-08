using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Web.Models;

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
        public IActionResult Create([FromForm]ProjectPostWithImageViewModel projectPostWithImage)
        {
            if (projectPostWithImage.ProjectPostImage != null)
            {
                // do other validations on your model as needed
                var x = projectPostWithImage.ProjectPostImage.FileName;
                var uniqueFileName = GetUniqueFileName(projectPostWithImage.ProjectPostImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", uniqueFileName);

                projectPostWithImage.ProjectPostImage.CopyTo(new FileStream(filePath, FileMode.Create));


                projectPostWithImage.ProjectPostOption.Multimedia = uniqueFileName;


            }
            //vale to 
            _projectPostService.CreateProjectPost(projectPostWithImage.ProjectPostOption);
            return RedirectToAction("Index", "Projects");
            
            //return View(projectPostWithImage);
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
