namespace pfm.Database.Entities
{
    public class TransactionEntity
    {
        public int id { get; set; }

 public string beneficiaryname { get; set; }
        public DateTime Date { get; set; }
      
        public string Direction { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int? mcc { get; set; }
        public string kind { get; set; }

    }
}