using NWBA.Service;
using System.Data.SqlClient;

namespace NWBA
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=(localdb)\\MYSQLLocalDB;Database=NWBA";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PreLoadService.LoadCustomersAsync(connection);
            }

        }

    }
}
