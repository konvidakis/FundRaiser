using FundRaiser.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser.Service
{
    public interface ITransactionService
    {
        public TransactionOption CreateTransaction(TransactionOption transactionOptions);

        public TransactionOption GetTransactionById(int transactionId);

        public TransactionOption UpdateTransaction(int transactionId, TransactionOption transactionOptions);

        public bool DeleteTransaction(int transactionId);
    }
}
