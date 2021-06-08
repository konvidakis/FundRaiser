using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using Microsoft.AspNetCore.Http;

namespace FundRaiser.Web.Models
{
    public class CreateProjectViewModel
    {
        public ProjectOption ProjectOption { get; set; }
        public List<RewardOption> RewardOptions { get; set; }
        public IFormFile ProjectImage { get; set; }

        public CreateProjectViewModel()
        {
            RewardOptions = new List<RewardOption>(2);
        }
    }
}
