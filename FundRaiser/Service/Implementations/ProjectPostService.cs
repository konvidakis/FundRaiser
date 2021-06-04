using FundRaiser.Database;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;
using Microsoft.EntityFrameworkCore;

namespace FundRaiser.Service.Implementations
{
    public class ProjectPostService : IProjectPostService

    {
        private readonly FundRaiserDbContext _db;

        public ProjectPostService(FundRaiserDbContext db)
        {
            _db = db;
        }

        public ProjectPostOption CreateProjectPost(ProjectPostOption projectPostOptions)
        {
            if (projectPostOptions == null)
            {
                return null;
            }

            Project project = _db.Projects.Find(projectPostOptions.ProjectId);
            ProjectPost projectPost = new()
            {
                Text = projectPostOptions.Text,
                Photo = projectPostOptions.Photo,
                Type = projectPostOptions.Type,
                TimeStamp = DateTime.Now,
                Project = project
            };
            _db.ProjectPosts.Add(projectPost);
            _db.SaveChanges();
            return new ProjectPostOption(projectPost);
        }

        public ProjectPostOption GetProjectPostById(int projectPostId)
        { 
            ProjectPost projectPost = _db.ProjectPosts.Include(p => p.Project).FirstOrDefault(o => o.ProjectPostId == projectPostId);
            if (projectPost == null)
            {
                return null;
            }

            return new ProjectPostOption(projectPost);
        }

        public ProjectPostOption UpdateProjectPost(int projectPostId, ProjectPostOption projectPostOptions)
        {
            ProjectPost dbProjectPost = _db.ProjectPosts.Find(projectPostId);
            if (dbProjectPost == null)
            {
                return null;
            }
            dbProjectPost.Text = projectPostOptions.Text;
            dbProjectPost.Photo = projectPostOptions.Photo;
            dbProjectPost.Type = projectPostOptions.Type;
            dbProjectPost.TimeStamp = projectPostOptions.TimeStamp;
            _db.SaveChanges();

            return new ProjectPostOption(dbProjectPost);
        }
        public bool DeleteProjectPost(int projectPostId)
        {
            ProjectPost dbProjectPost = _db.ProjectPosts.Find(projectPostId);
            if (dbProjectPost == null)
            {
                return false;
            }

            _db.ProjectPosts.Remove(dbProjectPost);
            _db.SaveChanges();
            return true;
        }

        public List<ProjectPostOption> GetAllProjectPosts(int projectId)
        {
            return ProjectPostToProjectPostOptions(_db.ProjectPosts.Include(p => p.Project).Where(p => p.Project.ProjectId == projectId).ToList());
        }

        public List<ProjectPostOption> ProjectPostToProjectPostOptions(List<ProjectPost> projectPosts)
        {
            List<ProjectPostOption> projectPostOptions = new List<ProjectPostOption>();
            projectPosts.ForEach(projectPost => projectPostOptions.Add(new ProjectPostOption(projectPost)));
            return projectPostOptions;
        }
    }
}
