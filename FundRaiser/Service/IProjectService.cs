using FundRaiser.Model;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
    interface IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOptions);

        public ProjectOption GetProjectById(int projectId);

        public ProjectOption UpdateProject(int projectId, ProjectOption projectOptions);

        public bool DeleteProject(int projectId);

        public List<Project> GetAllProjects();
        public List<Project> GetProjectsCreatedByUserId(int userId);

        public decimal? GetFinancialProgress(int projectId);
    }
}
