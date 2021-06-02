using FundRaiser.Database;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;

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

            Project project = _db.Projects.Find(projectPostOptions.ProjectPostId);
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
            ProjectPost projectPost = _db.ProjectPosts.Find(projectPostId);
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
    }
}
