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
            //optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = FundRaiser; uid = sa; password=admin!@#123");
            optionsBuilder.UseSqlServer("Server=tcp:serverfundraiser.database.windows.net,1433;Initial Catalog=FundRaiserDb;Persist Security Info=False;User ID=serveradmin;Password=admin!@#123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
