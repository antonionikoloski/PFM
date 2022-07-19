using AutoMapper;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;

namespace Product.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionEntity, pfm.Models.Transaction>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));
                 CreateMap<CreateTransactionCommand, TransactionEntity>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));

              
        }
    }
}