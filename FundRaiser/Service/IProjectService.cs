using FundRaiser.Model;
using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
    public interface IProjectService
    {
        public ProjectOption CreateProject(ProjectOption projectOptions);

        public ProjectOption GetProjectById(int projectId);

        public ProjectOption UpdateProject(int projectId, ProjectOption projectOptions);

        public bool DeleteProject(int projectId);

        public List<ProjectOption> GetAllProjects();

        public List<ProjectOption> GetProjectsCreatedByUserId(int userId);
        
        public List<ProjectOption> GetProjectsInvestedByUserId(int userId);

        public decimal? GetFinancialProgress(int projectId);

        public List<ProjectOption> GetProjectsByCategory(Category category);

        public List<ProjectOption> GetProjectsByTextSearch(String textSearch);

        public List<ProjectOption> GetProjectsTrending();

        public List<ProjectOption> ProjectToProjectOptions(List<Project> projects);
    }
}
