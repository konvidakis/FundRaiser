using System;
using System.Collections.Generic;
using FundRaiser.Database;
using FundRaiser.Model;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Service.Implementations;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace FundRaiser.Test
{
    public class ProjectServiceTest
    {
        private readonly IProjectService _projectService;
        private readonly ITestOutputHelper _testOutputHelper;

        public ProjectServiceTest(ITestOutputHelper testOutputHelper)
        {
            _projectService = new ProjectService(new FundRaiserDbContext());
            _testOutputHelper = testOutputHelper;

        }
        [Fact]
        public void GetProjectsCreatedByUserIdTest()
        {
            List<ProjectOption> projects = _projectService.GetProjectsCreatedByUserId(1);
            _testOutputHelper.WriteLine("Count"+projects.Count);
            foreach (var project in projects)
            {
                _testOutputHelper.WriteLine("projectId"+project.ProjectId);
                _testOutputHelper.WriteLine("--"+project.UserId);
                Assert.True(project.UserId==1,"The projects returned are all by the user with id 1");
            }
        }

        [Fact]
        public void GetProjectsByCategoryTest()
        {
            List<ProjectOption> projects = _projectService.GetProjectsByCategory(Category.Tech);
            foreach (var project in projects)
            {
                Assert.True(project.Category.Equals(Category.Tech), "The projects returned all have the correct category");
            }
        }

        [Fact]
        public void GetProjectsByTextSearchTest()
        {
            String searchText = "title";
            List<ProjectOption> projects = _projectService.GetProjectsByTextSearch(searchText);
            foreach (var project in projects)
            {
                _testOutputHelper.WriteLine("--" + project.Title);
                Assert.True(project.Title.ToLower().Contains(searchText), "The projects returned all contain 'title' in their title");
            }
        }
    }
}
