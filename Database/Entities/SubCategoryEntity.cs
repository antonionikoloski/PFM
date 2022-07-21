using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pfm.Models;

namespace pfm.Database.Entities
{
    public class SubCategoryEntity
    {
          [Key]
        public string code { get; set; }
          public string name { get; set; }
          
        [ForeignKey("Category")]
        public string parentcode { get; set; }
        public Category Category { get; set; }
        
        public Transaction Transaction { get; set; }
        [ForeignKey("Transaction")]
        public int? TransactionId { get; set; }
    }
}






