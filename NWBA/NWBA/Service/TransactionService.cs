using Microsoft.Extensions.Configuration;
using NWBA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NWBA.Service
{
    public class TransactionService
    {
        private string connectionString; 
        public TransactionService(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "SELECT * FROM Transaction";
                SqlCommand command = new SqlCommand(sql, connection);

                using(SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Transaction transaction = new Transaction
                        {
                            TransactionId = Convert.ToInt32(dataReader["Id"]),
                            TransactionType = Convert.ToChar(dataReader["TransactionId"]),
                            AccountNumber = Convert.ToInt32(dataReader["AccountNumber"]),
                            DestinationAccountNumber = Convert.ToInt32(dataReader["DestinationAccountNumber"]),
                            Amount = Convert.ToDecimal(dataReader["Amount"]),
                            Comment = Convert.ToString(dataReader["Comment"]),
                            TransactionTimeUtc = Convert.ToDateTime(dataReader["TransactionTimeUtc"])
                        };

                        transactions.Add(transaction);

                    }

                    connection.Close();
                }

                return transactions;
            }
        }
    }
}
