using System.Text.Json.Serialization;

namespace pfm.Models
{
    public  class Transaction 
    {
         public int id {get; set;}
         public DateTime Date { get; set; }
         public string direction { get; set; }
         public string beneficiaryname { get; set; }
             [JsonPropertyName("Direction")]
         public string Direction { get;set; }
         public double Amount {get; set;}
         public string Currency {get; set;}
         public int? mcc {get;set;}
         public string kind {get;set;}

         public ICollection<SubCategory> SubCategories {get; set;}


    }
}