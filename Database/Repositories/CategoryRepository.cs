



using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pfm.Commands;
using pfm.Database.Entities;

namespace pfm.Database.Repositories
{
     public class CategoryRepository : ICategoryRepository
     {
         private readonly TransactionDbContext _context;
           private readonly IMapper _mapper;
         public CategoryRepository(TransactionDbContext context,IMapper mapper)
         {
             _context = context;
             _mapper = mapper;
         }
         public async Task<List<CategoryEntity>> Create(List<CreateCategoryCommand> Categories)
         {
           

           
                 var categories=new List<CreateCategoryCommand>();
                    var subcategories=new List<CreateCategoryCommand>();
                 foreach(var com in Categories)
                 {
                        if(com.parentcode.Length==0)
                        {
                           
                            categories.Add(com);
                        }
                        else
                        {
                            subcategories.Add(com);
                        }
                      
                 }

               var cat=_mapper.Map<List<CategoryEntity>>(categories);
               var subcat=_mapper.Map<List<SubCategoryEntity>>(subcategories);
               
             

             _context.Categories.AddRange(cat);
                
             await _context.SaveChangesAsync();
             _context.SubCategories.AddRange(subcat);
                await _context.SaveChangesAsync();
            
            
             return cat;
         }

        
    }
}