using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;
using Microsoft.EntityFrameworkCore;

namespace FundRaiser.Service.Implementations
{
    public class TransactionService : ITransactionService
   
    {
        private readonly FundRaiserDbContext _db;
        public TransactionService(FundRaiserDbContext db)
        {
            _db = db;
        }
        
        public TransactionOption CreateTransaction(TransactionOption transactionOptions)
        {
            if (transactionOptions == null)
            {
                return null;
            }

            Project project = _db.Projects.Find(transactionOptions.ProjectId);
            User user = _db.Users.Find(transactionOptions.UserId);
            Reward reward = _db.Rewards.Find(transactionOptions.RewardId);
            Transaction transaction = new()
            {
                Amount = transactionOptions.Amount,
                TimeStamp = DateTime.Now,
                Reward = reward,
                Project = project,
                User = user
            };
            _db.Transactions.Add(transaction);
            project.AmountPledged = project.AmountPledged + transactionOptions.Amount;
            _db.SaveChanges();
            return new TransactionOption(transaction);
        }

        public TransactionOption GetTransactionById(int transactionId)
        {
            Transaction transaction = _db.Transactions.Include(u=>u.User)
                .Include(p=>p.Project)
                .Include(u=>u.Reward)
                .FirstOrDefault(o => o.TransactionId == transactionId);
            if (transaction == null)
            {
                return null;
            }

            return new TransactionOption(transaction);
        }
        public bool DeleteTransaction(int transactionId)
        {
            Transaction dbTransaction = _db.Transactions.Find(transactionId);
            if (dbTransaction == null)
            {
                return false;
            }

            _db.Transactions.Remove(dbTransaction);
            _db.SaveChanges();
            return true;
        }

        public TransactionOption UpdateTransaction(int transactionId, TransactionOption transactionOptions)
        {
            Transaction dbTransaction = _db.Transactions.Find(transactionId);
            if (dbTransaction == null)
            {
                return null;
            }
            dbTransaction.Amount = transactionOptions.Amount;
            dbTransaction.TimeStamp = transactionOptions.TimeStamp;
            _db.SaveChanges();

            return new TransactionOption(dbTransaction);
        }

    }
}
