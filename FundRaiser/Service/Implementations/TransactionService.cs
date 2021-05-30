using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;
using FundRaiser.Model;

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

            Transaction transaction = transactionOptions.GetTransaction();
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
            return new TransactionOption(transaction);
        }

        public TransactionOption GetTransactionById(int transactionId)
        {
            Transaction transaction = _db.Transactions.Find(transactionId);
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
            //dbTransaction.Reward = transactionOptions.Reward;
            _db.SaveChanges();

            return new TransactionOption(dbTransaction);
        }

    }
}
