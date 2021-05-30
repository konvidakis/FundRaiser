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
        public string Photo { get; set; }
        public PostType Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProjectId { get; set; }

        public ProjectPostOption() { }

        public ProjectPostOption(ProjectPost projectPost)
        {
            if (projectPost != null)
            {
                Text = projectPost.Text;
                Photo = projectPost.Photo;
                Type = projectPost.Type;
                ProjectPostId = projectPost.ProjectPostId;
                TimeStamp = projectPost.TimeStamp;
            }    
        }
        public ProjectPost GetProjectPost()
        {
            ProjectPost projectPost = new()
            {
                Text = Text,
                Photo = Photo,
                Type = Type,
                TimeStamp = DateTime.Now
            };
            return projectPost;
        }
    }
}
