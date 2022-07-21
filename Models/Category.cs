


using System.ComponentModel.DataAnnotations;

namespace pfm.Models
{
    public class Category
    {
        [Key]
        public string code {get; set;}
            #nullable enable
        public string? parentcode { get; set; }
        #nullable disable
        public string name {get; set;}
        
        
        public ICollection<SubCategory> SubCategories {get; set;}
       

    }
}