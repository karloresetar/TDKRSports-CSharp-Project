using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TDKRSports.Dapper
{
    public class DataAccess : IDataAccess
    {
        private readonly string connectionString;
        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection connectedDb = new SqlConnection(connectionString))
            {
                return connectedDb.QuerySingle<T>(sql, parameters);
            }
        }

        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection connectedDb = new SqlConnection(connectionString))
            {
                return connectedDb.Query<T>(sql, parameters).ToList();
            }
        }

        public void Execute<T>(string sql, T parameters)
        {
            using (IDbConnection connectedDb = new SqlConnection(connectionString))
            {
                connectedDb.Execute(sql, parameters);
            }
        }
    }
}
