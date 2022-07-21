



using pfm.Commands;
using pfm.Database.Entities;

namespace pfm.Database.Repositories{



    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> Create(List<CreateCategoryCommand> Categories);
       
    }
}