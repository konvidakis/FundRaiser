using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    public class ProjectPost
    {
        public int ProjectPostId { get; set; }
        public string Text { get; set; }
        public string Multimedia { get; set; }
        public DateTime TimeStamp { get; set; }
        public Project Project { get; set; }
    }
}
