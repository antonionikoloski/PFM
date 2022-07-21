

using System.ComponentModel.DataAnnotations;

namespace pfm.Database.Entities
{
    public class CategoryEntity
    {
       
       [Key]
        public string code { get; set; }
        #nullable enable
        public string? parentcode { get; set; }
        #nullable disable
        public string name { get; set; }
        public ICollection<SubCategoryEntity> SubCategories { get; set; }
    }
}