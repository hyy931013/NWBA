using System;
using System.Collections.Generic;
using System.Text;

namespace NWBA.Model
{
    public class Transaction
    {
        int TransactionId { get; set; }
        char TransactionType { get; set; }
        int AccountNumber { get; set; }
        int DestinationAccountNumber { get; set; }
        Decimal Amount { get; set; }
        string Comment { get; set; }
        DateTimeOffset TransactionTimUtc { get; set; }
    }
}
