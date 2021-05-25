using FundRaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class RewardOptions
    {
        public int RewardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal AmountRequired { get; set; }
        public Project Project { get; set; }
        // public List<Transaction> Transactions { get; set; }
    }
}
