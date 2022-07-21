


using pfm.Commands;
using pfm.Models;

namespace pfm.Services
{
    public interface ICategoryService
    {
    
        Task<List<CreateCategoryCommand>> Create(List<CreateCategoryCommand> Categories);
        Task<List<SubCategory>> Create_Pom(List<CreateCategoryCommand> Categories);
       
    }
}