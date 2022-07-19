using System.Transactions;
using pfm.Commands;

namespace pfm.Services
{
    public interface IPfmService
    {
    
        
        Task<List<Transaction>> CreateTransaction(List<CreateTransactionCommand> command);
       Task<Models.Transaction> Get(int Code);
      
    }
}