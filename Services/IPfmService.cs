using System.Transactions;

using pfm.Commands;
using pfm.Models;
using Pfm.Models;

namespace pfm.Services
{
    public interface IPfmService
    {
    
        
        Task<List<Models.Transaction>> CreateTransaction(List<CreateTransactionCommand> command);
       Task<Models.Transaction> Get(int Code);
        Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<Models.Transaction> CategorizeTransaction(int transactionid, string namecategory);
        Task<Models.Transaction> SplitTransactions(int transactionid);
    }
}