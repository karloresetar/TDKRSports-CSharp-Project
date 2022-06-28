using System;
using System.Collections.Generic;
using System.Linq;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Product GetProduct(int id)
        {
            return dataAccess.QuerySingle<Product, dynamic>("SELECT * FROM Product WHERE ProductId=@Id", new { Id = id });
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            List<Product> products;
            if (string.IsNullOrWhiteSpace(filter))
            {
                products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product", new { });
            }
            else
            {
                products = dataAccess.Query<Product, dynamic>("SELECT * FROM Product WHERE Name LIKE '%' + @Filter + '%'", new { Filter = filter });
            }
            return products.AsEnumerable();
        }
    }
}
