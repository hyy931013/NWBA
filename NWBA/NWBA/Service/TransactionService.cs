using Microsoft.Extensions.Configuration;
using NWBA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NWBA.Service
{
    public static class TransactionService
    {
        public static void AddTransaction(Transaction transaction, SqlConnection connection)
        {
            string sql = "INSERT INTO[dbo].[Transaction] ([TransactionType],[AccountNumber],[DestinationAccountNumber],[Amount] ,[Comment],[TransactionTimeUtc])"
            + $"VALUES ({transaction.TransactionType},{transaction.AccountNumber},{transaction.DestinationAccountNumber},{transaction.Amount},{transaction.Comment},{transaction.TransactionTimeUtc})";

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

        }

        public static List<Transaction> GetTransactions(SqlConnection connection)
        {
            List<Transaction> transactions = new List<Transaction>();

            using (connection)
            {
                //SqlDataReader
                connection.Open();

                string sql = "SELECT * FROM Transaction";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
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
