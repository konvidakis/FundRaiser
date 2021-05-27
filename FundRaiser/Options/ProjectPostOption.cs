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
        public DateTime TimeStamps { get; set; }
        public int ProjectId { get; set; }
    }
}
