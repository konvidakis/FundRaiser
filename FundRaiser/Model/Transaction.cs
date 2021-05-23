using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    class Transaction

    {
        public class Transaction
        {
            public int RewardId { get; set; }
            public int UserId { get; set; }
            public int ProjectId { get; set; }

            public decimal Amount { get; set; }
            public DateTime TimeStamp { get; set; }


        }
    }
}
}
