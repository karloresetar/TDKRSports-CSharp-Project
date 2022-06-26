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

            var data = new DataAccess(connectionString);
            var sqlString = "SELECT * FROM Products";
            var read = data.Query<Product, dynamic>(sqlString, new {});
            Console.Write(read);
            sqlString = "SELECT * FROM Products WHERE Name=@Name";
            var readByName = data.Query<Product, dynamic>(sqlString, new {Name = "adidas"});
            Console.Write(readByName);

            /*
            using (IDbConnection connectedDb = new SqlConnection(connectionString))
            {
                //READ
                var result = connectedDb.Query<Product>("SELECT * FROM Products");
                foreach(var record in result)
                {
                    Console.Write($"{record.Name}: { record.Description}");
                    Console.Write(record.Brand);
                    Console.Write(record.Price);
                }

                //CREATE
                var sqlString = @"INSERT INTO Products (ProductId, Name, Brand, Price, Description, ImageLink) 
                                VALUES (@ProductId,@Name,@Brand,@Price,@Description,@ImageLink)";
                var product = new Product();
                connectedDb.Execute(sqlString, product);
                //connectedDb.Execute(sqlString, new {ProductId = ..,Name = ..,Brand,Price,Description,ImageLink});

                //UPDATE
                sqlString = "UPDATE Products SET ImageLink=@NewImage WHERE Price=@Price";
                connectedDb.Execute(sqlString, new { NewImage = "href", Price = 14.99 });
            
                //DELETE
                sqlString = "DELETE FROM Products WHERE ProductId = @ProductId";
                connectedDb.Execute(sqlString, new { ProductId = 1 });
            }*/
        }
    }
}
