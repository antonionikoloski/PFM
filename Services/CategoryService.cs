



using AutoMapper;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Database.Repositories;
using pfm.Models;

namespace pfm.Services
{
    public class CategoryService : ICategoryService
    {

            private readonly ICategoryRepository _CategoryRepository;
            private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper, ISubCategoryRepository subCategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<List<CreateCategoryCommand>> Create(List<CreateCategoryCommand> Categories)
        {
         
          
               var result=await _CategoryRepository.Create(Categories);
                 return Categories;
        

        }

        public async Task<List<SubCategory>> Create_Pom(List<CreateCategoryCommand> SubCategories)
        {
               var entity=_mapper.Map<List<SubCategoryEntity>>(SubCategories);
               var result=await _subCategoryRepository.Create(entity);

               return _mapper.Map<List<SubCategory>>(result);
        }

        public async Task<Analysis<Analytics>> GetAnalysis(string catcode = null, string sd = null, string ed = null, string direction = null)
        {
           var result = await _CategoryRepository.GetAnalysis(catcode, sd, ed, direction);

            return _mapper.Map<Analysis<Models.Analytics>>(result);
        }
    }
}