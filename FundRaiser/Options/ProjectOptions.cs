using FundRaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class ProjectOptions
    {
        public int ProjectId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }
        public decimal SetGoal { get; set; }
        public decimal AmountPledged { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        //public List<Transaction> Transactions { get; set; }
        //public List<Reward> Rewards { get; set; }
        //public List<ProjectPost> ProjectPosts { get; set; }
    }
}
