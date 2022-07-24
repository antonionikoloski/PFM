



using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;
using System.Linq;
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
                foreach(var category in cat)
            {
                var exist_category = await _context.Categories.FirstOrDefaultAsync(p => p.code == category.code);
                if(exist_category!=null)
                {
                    cat.Remove(exist_category);
                }

            }
                   foreach(var category in subcat)
            {
                var exist_subcategory = await _context.SubCategories.FirstOrDefaultAsync(p => p.code == category.code);
                if(exist_subcategory!=null)
                {
                    subcat.Remove(exist_subcategory);
                }

            }

             _context.Categories.AddRange(cat);
                
             await _context.SaveChangesAsync();
             _context.SubCategories.AddRange(subcat);
                await _context.SaveChangesAsync();
            
            
             return cat;
         }

        public async Task<Analysis<Analytics>> GetAnalysis(string catcode = null, string startdate = null, string enddate = null, string direction = null)
        {
            

               var rangeData=_context.Transactions.AsQueryable();
               var categories=_context.Categories.AsQueryable();
               if(!string.IsNullOrEmpty(startdate)&&!string.IsNullOrEmpty(enddate))
               {
                DateTime start = DateTime.Parse(startdate);
              DateTime end = DateTime.Parse(enddate);
                    rangeData = _context.Transactions.Where(x => x.Date >= start && x.Date <= end);
               }
               else if(!string.IsNullOrEmpty(startdate))
               {
                DateTime start = DateTime.Parse(startdate);
              
                     rangeData = _context.Transactions.Where(x => x.Date >= start);
               }
               else if(!string.IsNullOrEmpty(enddate))
               {
            
              DateTime end = DateTime.Parse(enddate);
                    rangeData = _context.Transactions.Where(x =>x.Date <= end);
               }
               if(!string.IsNullOrEmpty(direction))
               {
                    rangeData = _context.Transactions.Where(x => x.Direction == direction);
               }
               if(!string.IsNullOrEmpty(catcode))
               {
                    categories = _context.Categories.Where(x => x.code == catcode);
               }

                var subcategories=_context.SubCategories.AsQueryable();
                    
                    
            
            var result =  rangeData.Join(subcategories, x => x.id, y => y.TransactionId, (x, y) => new { x, y }).ToList();
            var gas=new List<Analytics>();
            int count=0;
            double total=0;
            var p=result.Count;
            foreach(var pom in result)
            {
               for(int i=0;i<result.Count;i++)
               {
                 if(result[i].y.parentcode==pom.y.parentcode)
                 {
                     count++;
                      total+=result[i].x.Amount;
                 }
               }
               
                 var toadd=    new Analytics
                     {
                          catcode=pom.y.parentcode,
                          amount=total,
                            count=count
                     };
                
                bool containsItem = gas.Any(item => item.catcode == toadd.catcode);
                if(!containsItem)
                {
                    gas.Add(toadd);
                }
                
               
            }
            var final=new Analysis<Analytics>();
            final.Items=gas;
                
                return final;
        }
    }
}