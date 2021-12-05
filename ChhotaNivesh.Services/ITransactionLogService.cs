using ChhotaNivesh.Models.TransactionLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public interface ITransactionLogService
    {
        Task<IEnumerable<TransactionLog>> GetAll();

        Task<TransactionLog> Get(string id);

        Task<string> Create(TransactionLog TransactionLog);
       
    }
}
