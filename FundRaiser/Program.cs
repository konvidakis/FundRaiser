using System;
using System.Collections.Generic;
using System.Linq;
using FundRaiser.Database;
using FundRaiser.Model;
using FundRaiser.Options;
using FundRaiser.Service;
using FundRaiser.Service.Implementations;

namespace FundRaiser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using FundRaiserDbContext db = new();
            ProjectService projectService = new ProjectService(db);
            ProjectPostService projectPostService = new ProjectPostService(db);
            RewardService rewardService = new RewardService(db);
            UserService user = new UserService(db);
            TransactionService transactionService = new TransactionService(db);

            //ProjectOption projectOption = projectService.GetProjectById(11);
            //Console.WriteLine(projectOption.UserId);

            /*ProjectOption projectOption = new ProjectOption()
            {
               Title = "test12",
               Description = "adasafafsfsadsgfasda",
               UserId = 1,
               SetGoal = 110,
               AmountPledged = 22,
               Category = Category.Katigoria2
            };
            ProjectOption projectOption2 = projectService.CreateProject(projectOption);*/
            //---------GetProjectsByCategory
            /*List<Project> projects = projectService.GetProjectsByCategory(Category.Katigoria2);
            foreach (var project in projects)
            {
                Console.WriteLine(project.Title);
            }*/
            //---------GetProjectsByText
            /*List<Project> projects = projectService.GetProjectsByTextSearch("title");
            foreach (var project in projects)
            {
                Console.WriteLine(project.Title);
            }*/

            //-----------GetAllProjectPosts
            /*ProjectPostOption projectPostOption = new ProjectPostOption()
            {
                Text = "Texssfasgaaft",
                Multimedia = "fa",
                ProjectId = 6
            };
            //projectPostService.CreateProjectPost(projectPostOption);  
            List<ProjectPost> projectPosts = projectPostService.GetAllProjectPosts(6);
            foreach (var projectPost in projectPosts)
            {
                Console.WriteLine(projectPost.Multimedia);
            }*/



            /*List<Reward> rewards = rewardService.GetRewardsByUserId(1);
            foreach (var reward in rewards)
            {
                Console.WriteLine(reward.Title);
            }*/


            /*TransactionOption transactionOption = new TransactionOption()
            {
                UserId = 1,
                ProjectId = 9,
                RewardId = 6
            };
            transactionService.CreateTransaction(transactionOption);
            List<Project> projects = projectService.GetProjectsTrending();
            foreach (var project in projects)
            {
                Console.WriteLine(project.ProjectId);
            }*/
        }
    }
}
