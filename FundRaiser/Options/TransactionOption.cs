using FundRaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Options
{
    public class TransactionOption
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public int RewardId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public TransactionOption() {}
        public TransactionOption(Transaction transaction)
        {
            if (transaction != null)
            {
                TransactionId = transaction.TransactionId;
                Amount = transaction.Amount;
                TimeStamp = transaction.TimeStamp;
                RewardId = transaction.Reward.RewardId;
                UserId = transaction.User.UserId;
                ProjectId = transaction.Project.ProjectId;
            }
        }
    }
}
