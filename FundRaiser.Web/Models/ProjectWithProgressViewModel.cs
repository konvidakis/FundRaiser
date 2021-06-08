using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;

namespace FundRaiser.Web.Models
{
    public class ProjectWithProgressViewModel
    {
        public ProjectOption ProjectOption { get; set; }
        public decimal FinancialProgress { get; set; }
    }
}
