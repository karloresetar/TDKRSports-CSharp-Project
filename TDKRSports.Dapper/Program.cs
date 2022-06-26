using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TDKRSports.Database;Integrated Security=true";
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var result = conn.Query<Product>("SELECT * FROM Products");
                foreach(var record in result)
                {
                    Console.Write(record.Name);
                    Console.Write(record.Brand);
                    Console.Write(record.Price);
                }
            }
        }
    }
}
