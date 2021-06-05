using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;

namespace FundRaiser.Web.Models
{
    public class ProjectPageViewModel
    {
        public ProjectOption ProjectOption { get; set; }
        public List<ProjectPostOption> ProjectPostOptions { get; set; }
        public List<RewardOption> RewardOptions { get; set; }
    }
}
