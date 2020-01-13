using Microsoft.Extensions.Configuration;
using NWBA.Model;
using System.Data.SqlClient;

namespace NWBA.Service
{
    public static class CustomerService
    {
        public static void AddCustomer(Customer customer, SqlConnection connection)
        {
            string sql = "Insert into [dbo].[Customer] (CustomerID,Name,Address,City,PostCode) " +
                $"VALUES({customer.CustomerId},{customer.Name},{customer.Address},{customer.City},{customer.PostCode}";

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
