using System;

namespace NWBA.Model
{
    public class Account
    {
        int AccountNumber { get; set; }
        char AccountType { get; set; }
        int CustomerId { get; set; }
        Decimal Balance { get; set; }
    }
}
