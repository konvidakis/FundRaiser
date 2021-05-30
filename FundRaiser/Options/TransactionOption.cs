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
        public Reward Reward { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }


        public TransactionOption(Transaction transaction)
        {
            if (transaction != null)
            {
                TransactionId = transaction.TransactionId;
                Amount = transaction.Amount;
                TimeStamp = transaction.TimeStamp;
                Reward = transaction.Reward;

            }
        }

        public Transaction GetTransaction()
        {
            Transaction transaction = new()
            {                 
                TransactionId = TransactionId,
                Amount = Amount,
                TimeStamp = DateTime.Now,
                Reward = Reward,
            };
            return transaction;
        }
    }
}
