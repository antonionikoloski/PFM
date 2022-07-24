

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pfm.Database.Entities
{
    public class SplitsEntity{
     [Key]
        public int id { get; set; }
        [ForeignKey("TransactionEntity")]
        public int transactionid { get; set; }
        
        [ForeignKey("CategoryEntity")]
        public string categorycode { get; set; }
        public double Amount {get; set;}
        public CategoryEntity CategoryEntity {get; set;}
        public TransactionEntity TransactionEntity {get; set;}
    }
}