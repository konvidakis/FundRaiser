﻿using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;

namespace FundRaiser.Service.Implementations
{
    public class ProjectService : IProjectPostService
    {
        private readonly FundRaiserDbContext _db;

        public ProjectService(FundRaiserDbContext db)
        {
            _db = db;
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
