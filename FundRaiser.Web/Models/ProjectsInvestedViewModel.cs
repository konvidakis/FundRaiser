using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;

namespace FundRaiser.Web.Models
{
    public class ProjectsInvestedViewModel
    {
        public ProjectOption ProjectOption { get; set; }
        public RewardOption RewardOption { get; set; }
        public decimal? FinancialProgress { get; set; }
    }
}
