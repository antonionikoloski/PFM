

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace pfm.Commands
{
     public class CreateTransactionCommand
     {
        [Required]
         public int id {get; set;}
        [Required]
     
        public string beneficiaryname { get; set; }
         public DateTime Date { get; set; }
         public string Direction { get;set; }
         public double Amount {get; set;}
         public string Currency {get; set;}
         public int? mcc {get;set;}
         public string kind {get;set;}
     }
}