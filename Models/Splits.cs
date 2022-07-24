


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfm.Models
{
    public class Splits
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Transaction")]
        public int transactionid { get; set; }
        
        [ForeignKey("Category")]
        public string categorycode { get; set; }
        public int Amount {get; set;}
        public Category Category {get; set;}
        public Transaction Transaction {get; set;}
    }
}