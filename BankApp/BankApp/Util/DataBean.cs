using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Data
{
    /// <summary>
    /// Holds the User home data
    /// </summary>
    public class UserHomeAccountData
    {
        public Int64 id { get; set; }
        public String active { get; set; }
        public String BankName { get; set; }
        public String AccountType { get; set; }
        public Int64 Balance { get; set; }
    }

    /// <summary>
    /// Holds the bank transaction data
    /// </summary>
    public class BankTransaction
    {
        public Int64 id { get; set; }
        public String active { get; set; }
        public String TransactionType { get; set; }
        public String TransactionDate { get; set; }
        public String Description { get; set; }
        public Int64 Amount { get; set; }
        public Int64 EndingBalance { get; set; }
        public String BankId { get; set; }
    }
}
