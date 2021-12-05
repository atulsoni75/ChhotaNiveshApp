using ChhotaNivesh.Models.Product;
using ChhotaNivesh.Models.TransactionLog;
using ChhotaNivesh.Models.Users;
using ChhotaNivesh.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Business
{
    public class TransactionLogManager : ITransactionLogManager
    {
        private ITransactionLogService _transactionLogService;

        public TransactionLogManager(ITransactionLogService transactionLogService)
        {
            _transactionLogService = transactionLogService;
        }

        public Task<string> Create(TransactionLog transactionLog)
        {
            return _transactionLogService.Create(transactionLog);
        }

        public Task<TransactionLog> Get(string id) => _transactionLogService.Get(id);

        public Task<IEnumerable<TransactionLog>> GetAll() =>
            _transactionLogService.GetAll();

    }
}
