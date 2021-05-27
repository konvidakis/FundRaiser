using FundRaiser.Database;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service.Implementations
{
    public class ProjectPostService : IProjectPostService

    {
        private readonly FundRaiserDbContext db;

        public ProjectPostService(FundRaiserDbContext _db)
        {
            db = _db;
        }

        public ProjectPostOption CreateProjectPost(ProjectPostOption projectPostOptions)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProjectPost(int projectPostId)
        {
            throw new NotImplementedException();
        }

        public ProjectPostOption GetProjectPostById(int projectPostId)
        {
            throw new NotImplementedException();
        }

        public ProjectPostOption UpdateProjectPost(int projectPostId, ProjectPostOption projectPostOptions)
        {
            throw new NotImplementedException();
        }
    }
}
