using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;
using Microsoft.EntityFrameworkCore;

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

            Project project = _db.Projects.Include(p => p.User).FirstOrDefault(o => o.ProjectId == projectId);
            if (project == null)
            {
                return null;
            }
            //Console.WriteLine("-- "+project.User.UserId);
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

        public List<ProjectOption> GetAllProjects()
        {
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).ToList());
        }

        public List<ProjectOption> GetProjectsCreatedByUserId(int userId)
        {
            //return _db.Users.Find(userId).Projects.ToList();
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).Where(p => p.User.UserId == userId).ToList());
        }

        public List<ProjectOption> GetProjectsInvestedByUserId(int userId)
        {
            //return _db.Transactions.Select(p => p.Project).Where(t => t.User.UserId == userId).ToList();
            var x=_db.Transactions.Include(t => t.User).Where( t=> t.User.UserId == userId);
            var y = x.Select(p => p.Project);
            y = y.Include(t => t.User).Distinct();
            return ProjectToProjectOptions(y.ToList());
            //_db.Projects.Include(t => t.User)
            //return ProjectToProjectOptions(_db.Transactions.Where(t => t.User.UserId == userId).Select(p => p.Project).Distinct().ToList());
            //return _db.Users.Find(userId).Transactions.Select(t => t.Project).Distinct().ToList();

            //return ProjectToProjectOptions(_db.Transactions.Include(t => t.User).Where(t => t.User.UserId == userId).Select(p => p.Project).Distinct().ToList());

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

        public List<ProjectOption> GetProjectsByCategory(Category category)
        {
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).Where(p => p.Category == category).ToList());
        }

        public List<ProjectOption> GetProjectsByTextSearch(String textSearch)
        {
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).Where(x => x.Title.ToLower().Contains(textSearch.ToLower())).ToList());
        }

        public List<ProjectOption> GetProjectsByCategoryAndTextSearch(String textSearch, Category category)
        {
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).Where(x => x.Title.ToLower().Contains(textSearch.ToLower()) && x.Category == category).ToList());
        }

        //returns the projects ordered by the most transactions
        public List<ProjectOption> GetProjectsTrending()
        {
            //return _db.Transactions
            return ProjectToProjectOptions(_db.Projects.Include(t => t.User).OrderByDescending(p => p.Transactions.Count()).ToList());
        }

        public List<ProjectOption> ProjectToProjectOptions(List<Project> projects)
        {
            List<ProjectOption> projectOptions = new List<ProjectOption>();
            projects.ForEach(project => projectOptions.Add(new ProjectOption(project)));
            return projectOptions;
        }

    }
}
