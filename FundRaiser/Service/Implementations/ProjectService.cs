using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;

namespace FundRaiser.Service.Implementations
{
    public class ProjectService : IProjectService
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

            User user = _db.Users.Find(projectOptions.UserId);
            //Project project = projectOptions.GetProject();
            Project project = new()
            {
                Category = projectOptions.Category,
                Title = projectOptions.Title,
                Logo = projectOptions.Logo,
                TimeStamp = DateTime.Now,
                Description = projectOptions.Description,
                SetGoal = projectOptions.SetGoal,
                AmountPledged = projectOptions.AmountPledged,
                StartDate = projectOptions.StartDate,
                EndDate = projectOptions.EndDate,
                User = user
            };

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

        public List<Project> GetAllProjects()
        {
            return _db.Projects.ToList();
        }

        public List<Project> GetProjectsCreatedByUserId(int userId)
        {

            //return _db.Users.Find(userId).Projects.ToList();
            return _db.Projects.Where(p => p.User.UserId == userId).ToList();
        }

        public List<Project> GetProjectsInvestedByUserId(int userId)
        {
            //return _db.Transactions.Select(p => p.Project).Where(t => t.User.UserId == userId).ToList();
            return _db.Transactions.Where(t => t.User.UserId == userId).Select(p => p.Project).Distinct().ToList();
        }

        public decimal? GetFinancialProgress(int projectId)
        {
            Project project = _db.Projects.Find(projectId);
            if (project == null)
            {
                return null;
            }

            return (project.AmountPledged / project.SetGoal)*100;
        }

    }
}
