using System.Transactions;
using AutoMapper;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Database.Repositories;

namespace pfm.Services
{
    public class PfmService : IPfmService
    {
       
            private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public PfmService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
      

   
        public async Task<List<Transaction>> CreateTransaction(List<CreateTransactionCommand> command)
        {
               var entity=_mapper.Map<List<TransactionEntity>>(command);
               var result=await _transactionRepository.Create(entity);

               return _mapper.Map<List<Transaction>>(result);
        }

        public async Task<Models.Transaction> Get(int Code)
        {
             var transaction = await _transactionRepository.Get(Code);

            if (transaction == null)
            {
                return null;
            }

            return _mapper.Map<Models.Transaction>(transaction);
        }
    }
}