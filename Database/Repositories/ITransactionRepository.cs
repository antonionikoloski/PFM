

using System.Transactions;
using pfm.Commands;

namespace pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransaction(CreateTransactionCommand command);
      
    }
}