using System;
using System.Collections.Generic;
using System.Text;

namespace NWBA.Model
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public List<AccountDetails> Accounts { get; set; }
    }
}
