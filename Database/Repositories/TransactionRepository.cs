

using System.Transactions;
using Microsoft.EntityFrameworkCore;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;
using Pfm.Models;

namespace pfm.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
           private readonly TransactionDbContext _dbContext;

        public TransactionRepository(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEntity> CategorizeTransaction(int transactionid, string namecategory)
        {
            var transaction=await _dbContext.Transactions.FirstOrDefaultAsync(p => p.id == transactionid);
            var subcategory=await _dbContext.SubCategories.FirstOrDefaultAsync(p => p.name == namecategory);
            if(transaction!=null&&subcategory!=null)
            {
                subcategory.TransactionId=transactionid;
                 _dbContext.Update(subcategory);
                await _dbContext.SaveChangesAsync();

            }
            return transaction; 
        }

        public async Task<TransactionEntity> Create(TransactionEntity transaction)
        {
            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<List<TransactionEntity>> Create(List<TransactionEntity> Transactions)
        {
            foreach(var transaction in Transactions)
            {
                var exist_transaction = await _dbContext.Transactions.FirstOrDefaultAsync(p => p.id == transaction.id);
                if(exist_transaction!=null)
                {
                    Transactions.Remove(transaction);
                }

            }
             _dbContext.Transactions.AddRange(Transactions);

            await _dbContext.SaveChangesAsync();

            return Transactions;
        }

        public async Task<TransactionEntity> Get(int code)
        {
           
        
            return await _dbContext.Transactions.FirstOrDefaultAsync(p => p.id == code);
        
        }

        public async Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
             var query = _dbContext.Transactions.AsQueryable();

            var totalCount = query.Count();

            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
               
                  
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);
                        
               
                 
            } 
           

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new PagedSortedList<TransactionEntity>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        
        }

        public async Task<TransactionEntity> SplitTransaction(int transactionid)
        {
            int count_amount=0;
             var subcategories= _dbContext.SubCategories.Where(p => p.TransactionId == transactionid).ToList();
             var exist_transaction= _dbContext.Splits.Where(p => p.transactionid == transactionid).ToList();
             var trasaction=_dbContext.Transactions.FirstOrDefault(p => p.id == transactionid);
             var pom=_dbContext.Splits;
             var pom_pom=exist_transaction.Count;
             if(exist_transaction.Count==0)
             {
                     var split=new List<SplitsEntity>();
                     foreach(var subcategory in subcategories)
                     {
                        for(int i=0;i<subcategories.Count;i++)
                        {
                            if(subcategory.parentcode==subcategories[i].parentcode)
                            {
                                  count_amount+=1;
                            }
                        }
                         var toadd=    new SplitsEntity
                     {
                          transactionid=transactionid,
                          Amount=trasaction.Amount*count_amount,
                          categorycode=subcategory.parentcode,
                            
                     };
                      bool containsItem = split.Any(item => item.categorycode == toadd.categorycode);
                      if(!containsItem)
                      {
                          split.Add(toadd);
                      }
                     }

                       _dbContext.Splits.AddRange(split);
                         await _dbContext.SaveChangesAsync();

             }
             else
             {
                    var splits_exist=_dbContext.Splits.Where(p => p.transactionid == transactionid).ToList();
                    foreach(var split in splits_exist)
                    {
                         var category_exist=_dbContext.Categories.FirstOrDefault(p => p.code == split.categorycode);
                         if(category_exist==null)
                         {
                                _dbContext.Splits.Remove(split);
                                await _dbContext.SaveChangesAsync();
                         }
                    }
             }
                return trasaction;
        }
    }
}