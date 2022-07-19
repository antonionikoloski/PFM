

using System.Transactions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<TransactionEntity>> Create(List<TransactionEntity> Transactions)
        {
             _dbContext.Transactions.AddRange(Transactions);

            await _dbContext.SaveChangesAsync();

            return Transactions;
        }

        public async Task<TransactionEntity> Get(int code)
        {
           
        
            return await _dbContext.Transactions.FirstOrDefaultAsync(p => p.id == code);
        
        }
    }
}