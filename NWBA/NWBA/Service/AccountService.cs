using NWBA.Model;
using System.Data.SqlClient;

namespace NWBA.Service
{
    public static class AccountService
    {
        public static void AddAccount(Account account, SqlConnection connection)
        {
            string sql = "INSERT INTO[dbo].[Account] ([AccountNumber] ,[AccountType],[CustomerID],[Balance])"+
                $"VALUES ({account.AccountNumber},{account.AccountType},{account.CustomerId},{account.Balance})";

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
