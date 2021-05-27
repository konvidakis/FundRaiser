using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser.Database;

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
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public TransactionOption GetTransactionById(int transactionId)
        {
            throw new NotImplementedException();
        }

        public TransactionOption UpdateTransaction(int transactionId, TransactionOption transactionOptions)
        {
            throw new NotImplementedException();
        }
    }
}
