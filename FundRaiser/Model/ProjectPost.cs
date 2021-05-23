using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    public class ProjectPost
    {
        public  string Text { get; set; }
        public string photo { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamps { get; set; }
        public List<ProjectId> projectIds { get; set; }
    }
}
