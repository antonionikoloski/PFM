

using System.Transactions;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;
using Pfm.Models;

namespace pfm.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntity>> Create(List<TransactionEntity> Transactions);
         Task<TransactionEntity> Get(int code);
          Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
            Task<TransactionEntity> CategorizeTransaction(int transactionid, string namecategory);
    }
}