using System;
using System.Collections.Generic;
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
            ProjectPostOption projectPostOption = new ProjectPostOption()
            {
                Text = "text",
                Photo = "photo",
                TimeStamp = DateTime.Now,
                Type = PostType.Photo
                
            };

            using FundRaiserDbContext db = new();
            IProjectPostService projectPostService = new ProjectPostService(db);
            //projectPostService.CreateProjectPost(projectPostOption);

            bool result=projectPostService.DeleteProjectPost(1);
            Console.WriteLine(result);

        }
    }
}
