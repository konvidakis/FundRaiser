using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Model;
using Microsoft.EntityFrameworkCore;

namespace FundRaiser.Database
{
    public class FundRaiserDbContext:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPost> ProjectPosts { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //for test cases. The Web app takes this from startup with DI
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source = localhost; Initial Catalog = FundRaiser; uid = sa; password=admin!@#123");
            }
        }

        public FundRaiserDbContext(DbContextOptions<FundRaiserDbContext> options) : base(options) { }

    }
}
