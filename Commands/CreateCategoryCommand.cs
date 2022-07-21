using System.ComponentModel.DataAnnotations;

namespace pfm.Commands
{
    public class CreateCategoryCommand
    {
        [Required]
        public string code { get; set; }
        #nullable enable
        public string? parentcode { get; set; }
        #nullable disable
        [Required]
        public string name { get; set; }
        
    }
}