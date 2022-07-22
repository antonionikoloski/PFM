



using pfm.Commands;
using pfm.Database.Entities;
using pfm.Models;

namespace pfm.Database.Repositories{



    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> Create(List<CreateCategoryCommand> Categories);
         Task<Analysis<Analytics>> GetAnalysis(string catcode=null, string startdate=null, string enddate=null, string direction=null);
       
    }
}