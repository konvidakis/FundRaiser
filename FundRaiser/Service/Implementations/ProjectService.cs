using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;

namespace FundRaiser.Service.Implementations
{
    public class ProjectService : IProjectServices
    {
        private readonly FundRaiserDbContext _db;

        public ProjectService(FundRaiserDbContext db)
        {
            _db = db;
        }

        public ProjectOption CreateProject(ProjectOption projectOptions)
        {
            if (projectOptions == null)
            {
                return null;
            }

            Project project = projectOptions.GetProject();
            _db.Projects.Add(project);
            _db.SaveChanges();
            return new ProjectOption(project);
        }
    

        public bool DeleteProject(int projectId)
        {
            Project dbProject = _db.Projects.Find(projectId);
            if (dbProject == null)
            {
                return false;
            }

            _db.Projects.Remove(dbProject);
            _db.SaveChanges();
            return true;
        }

        public ProjectOption GetProjectById(int projectId)
        {
            Project project = _db.Projects.Find(projectId);
            if (project == null)
            {
                return null;
            }

            return new ProjectOption(project);
        }

        public ProjectOption UpdateProject(int projectId, ProjectOption projectOptions)
        {
            Project dbProject = _db.Projects.Find(projectId);
            if (dbProject == null)
            {
                return null;
            }
            dbProject.Category = projectOptions.Category;
            dbProject.Title = projectOptions.Title;
            dbProject.Logo = projectOptions.Logo;
            dbProject.TimeStamp = projectOptions.TimeStamp;
            dbProject.Description = projectOptions.Description;
            dbProject.AmountPledged = projectOptions.AmountPledged;
            dbProject.SetGoal = projectOptions.SetGoal;
            dbProject.StartDate = projectOptions.StartDate;
            dbProject.EndDate = projectOptions.EndDate;
            _db.SaveChanges();

            return new ProjectOption(dbProject);
        }
    }
}
