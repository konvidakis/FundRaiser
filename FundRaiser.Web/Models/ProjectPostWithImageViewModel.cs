using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundRaiser.Options;
using Microsoft.AspNetCore.Http;

namespace FundRaiser.Web.Models
{
    public class ProjectPostWithImageViewModel
    {
        public ProjectPostOption ProjectPostOption { get; set; }
        public IFormFile ProjectPostImage { get; set; }
    }
}
