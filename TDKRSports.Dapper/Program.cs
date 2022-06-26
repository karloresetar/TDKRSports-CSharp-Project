using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDKRSports.Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TDKR_sport_db;Integrated Security=true";
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var result = conn.Query("SELECT * FROM Products");
                foreach(var record in result)
                {
                    Console.Write(record.Name);
                }
            }
        }
    }
}
