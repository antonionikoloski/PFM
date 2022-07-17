

using System.Transactions;
using pfm.Commands;
using pfm.Database.Entities;

namespace pfm.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
           private readonly TransactionDbContext _dbContext;

        public TransactionRepository(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEntity> Create(TransactionEntity transaction)
        {
            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();

            return transaction;
        }

        public Task<Transaction> CreateTransaction(CreateTransactionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}