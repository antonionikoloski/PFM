

using System.Transactions;
using pfm.Commands;
using pfm.Database.Entities;

namespace pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntity>> Create(List<TransactionEntity> Transactions);
         Task<TransactionEntity> Get(int code);
      
    }
}