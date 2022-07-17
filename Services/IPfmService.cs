using System.Transactions;
using pfm.Commands;

namespace pfm.Services
{
    public interface IPfmService
    {
    
        
        Task<Transaction> CreateTransaction(CreateTransactionCommand command);
      
    }
}