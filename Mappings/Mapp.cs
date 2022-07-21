using AutoMapper;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;
using Pfm.Models;

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

                 CreateMap<PagedSortedList<TransactionEntity>, PagedSortedList<pfm.Models.Transaction>>();
                    
                       CreateMap<CreateCategoryCommand, CategoryEntity>()
                .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
                 CreateMap<CategoryEntity, pfm.Models.Category>();
                    CreateMap<CreateCategoryCommand, SubCategoryEntity>()
                    .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
                    CreateMap<SubCategoryEntity, pfm.Models.SubCategory>();
              
        }
    }
}