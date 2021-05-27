using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
    public interface IProjectPostService
    {
        public ProjectPostOption CreateProjectPost(ProjectPostOption projectPostOptions);

        public ProjectPostOption GetProjectPostById(int projectPostId);

        public ProjectPostOption UpdateProjectPost(int projectPostId, ProjectPostOption projectPostOptions);

        public bool DeleteProjectPost(int projectPostId);

    }
}
