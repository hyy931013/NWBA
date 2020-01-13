using NWBA.Model;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.Json;

namespace NWBA.Service
{
    public static class PreLoadService
    {
        private static readonly HttpClient client = new HttpClient();
        public static async void LoadCustomersAsync(SqlConnection connection)
        {
            // TODO: Fix stream and desrialization - Stream doesn't work but GetString works
            var customerStream = client.GetStreamAsync("https://coreteaching01.csit.rmit.edu.au/~e87149/wdt/services/customers/");

            CustomerDetails[] customerDetailsList = await JsonSerializer.DeserializeAsync<CustomerDetails[]>(await customerStream);

            foreach (var details in customerDetailsList)
            {
                CustomerService.AddCustomer(
                    new Customer
                    {
                        CustomerId = details.CustomerId,
                        Name = details.Name,
                        Address = details.Address,
                        City = details.City,
                        PostCode = details.PostCode
                    }, connection);

                foreach (var account in details.Accounts)
                {
                    AccountService.AddAccount(
                        new Account
                        {
                            AccountNumber = account.AccountNumber,
                            AccountType = account.AccountType,
                            CustomerId = account.CustomerId,
                            Balance = account.Balance
                        }, connection
                        );
                    foreach (var transaction in account.Transactions)
                    {
                        TransactionService.AddTransaction(
                            new Transaction
                            {
                                TransactionId = account.Transactions.IndexOf(transaction),
                                Amount = transaction.Amount,
                                Comment = transaction.Comment,
                                TransactionType = transaction.TransactionType,
                                AccountNumber = transaction.AccountNumber,
                                DestinationAccountNumber = transaction.DestinationAccountNumber,
                                // TODO: Check deserilization for TransactionTimeUtc
                                TransactionTimeUtc = transaction.TransactionTimeUtc
                            }, connection);

                    }
                }
            }

        }

        public static void LoadLogins()
        {
            //TODO
        }
    }
}
