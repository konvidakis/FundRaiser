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

            ProjectOption projectOption = new ProjectOption()
            {
               Title = "Title 1",
               Description = "adasafafsfsadsgfasda",
               UserId = 1,
               SetGoal = 110,
               AmountPledged = 22
            };


            List<Reward> rewards = rewardService.GetRewardsByUserId(1);
            foreach (var reward in rewards)
            {
                Console.WriteLine(reward.Title);
            }
            //ProjectOption projectOption2 = projectService.CreateProject(projectOption);
            //Console.WriteLine(projectOption2.UserId);

            /*TransactionOption transactionOption = new TransactionOption()
            {
                UserId = 1,
                ProjectId = 3,
                RewardId = 6
            };

            TransactionOption transactionOption2 = new TransactionOption()
            {
                UserId = 1,
                ProjectId = 4,
                RewardId = 7
            };

             TransactionService transactionService = new TransactionService(db);
            transactionService.CreateTransaction(transactionOption);
            transactionService.CreateTransaction(transactionOption2);

            RewardService rewardService = new RewardService(db);

            List<Reward> rewards = rewardService.GetRewardsByUserId(1);
            foreach (var reward in rewards)
            {
                Console.WriteLine(reward.Title);
            }*/

            /*List<Project> projects = projectService.GetAllProjects();
            foreach (var reward in rewards)
            {
                Console.WriteLine(reward.Title);
            }*/


            /*List<Project> projects = projectService.GetProjectsInvestedByUserId(1);
            foreach (var project in projects)
            {
                Console.WriteLine(project.Title);
            }*/
            
            


        }
    }
}
