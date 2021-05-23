using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    public class Project
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

        public User User { get; set; }
    }
}
