


using pfm.Database.Entities;

namespace pfm.Database.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategoryEntity>> Create(List<SubCategoryEntity> Categories);
       
    }
}