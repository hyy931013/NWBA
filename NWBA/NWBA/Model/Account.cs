using System;

namespace NWBA.Model
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public char AccountType { get; set; }
        public int CustomerId { get; set; }
        public Decimal Balance { get; set; }
    }
}
