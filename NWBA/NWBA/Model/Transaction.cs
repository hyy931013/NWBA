using System;

namespace NWBA.Model
{
    public class Transaction
    {
       public int? TransactionId { get; set; }
       public char? TransactionType { get; set; }
       public int? AccountNumber { get; set; }
       public int? DestinationAccountNumber { get; set; }
       public Decimal? Amount { get; set; }
       public string Comment { get; set; }
       public DateTimeOffset? TransactionTimeUtc { get; set; }
    }
}
