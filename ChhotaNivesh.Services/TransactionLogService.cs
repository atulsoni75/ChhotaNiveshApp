using ChhotaNivesh.DBCore;
using ChhotaNivesh.Models.TransactionLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public class TransactionLogService : ITransactionLogService
    {        
        private IRepository<TransactionLog> _TransactionLogRepository;

        public TransactionLogService(IRepository<TransactionLog> TransactionLogRepository)
        {
            _TransactionLogRepository = TransactionLogRepository;
        }

        public Task<IEnumerable<TransactionLog>> GetAll() =>
            _TransactionLogRepository.GetAll();

      
        public Task<TransactionLog> Get(string id) =>
            _TransactionLogRepository.Get(id);

        public async Task<string> Create(TransactionLog transactionLog)
        {
            var transactionLogResponse = await _TransactionLogRepository.Create(transactionLog);

            return transactionLogResponse.Id;
        }

    }
}
