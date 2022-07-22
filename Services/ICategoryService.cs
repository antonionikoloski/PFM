


using pfm.Commands;
using pfm.Models;

namespace pfm.Services
{
    public interface ICategoryService
    {
    
        Task<List<CreateCategoryCommand>> Create(List<CreateCategoryCommand> Categories);
        Task<List<SubCategory>> Create_Pom(List<CreateCategoryCommand> Categories);
       Task<Analysis<Models.Analytics>> GetAnalysis(string catcode=null, string sd=null, string ed=null, string direction=null);
    }
}