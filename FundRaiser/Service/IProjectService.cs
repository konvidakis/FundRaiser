using FundRaiser.Model;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
    interface IProjectServices
    {
        public ProjectOption CreateProject(ProjectOption projectOptions);

        public ProjectOption GetProjectById(int projectId);

        public ProjectOption UpdateProject(int projectId, ProjectOption projectOptions);

        public bool DeleteProject(int projectId);

    }
}
