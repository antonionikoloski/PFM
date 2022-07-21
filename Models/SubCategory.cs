


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfm.Models
{
    public class SubCategory
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