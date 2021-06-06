using FundRaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class ProjectPostOption
    {
        public int ProjectPostId { get; set; }
        public string Text { get; set; }
        public string Multimedia { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProjectId { get; set; }

        public ProjectPostOption() { }
        public ProjectPostOption(ProjectPost projectPost)
        {
            if (projectPost != null)
            {
                Text = projectPost.Text;
                Multimedia = projectPost.Multimedia;
                ProjectPostId = projectPost.ProjectPostId;
                ProjectId = projectPost.Project.ProjectId;
                TimeStamp = projectPost.TimeStamp;
            }    
        }
    }
}
