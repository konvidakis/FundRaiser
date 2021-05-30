using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Model
{
    public class Transaction
    {
            public int TransactionId { get; set; }
            public decimal Amount { get; set; }
            public DateTime TimeStamp { get; set; }
            public Reward Reward { get; set; }
            public User User { get; set; }
            public Project Project { get; set; }

    }
}


