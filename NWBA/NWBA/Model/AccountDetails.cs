using System;
using System.Collections.Generic;

namespace NWBA.Model
{
    public class AccountDetails
    {
        public int AccountNumber { get; set; }
        public char AccountType { get; set; }
        public int CustomerId { get; set; }
        public Decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
