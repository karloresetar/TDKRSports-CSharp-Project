using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.PluginInterfaces.DataStore
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);
        Product GetProduct(int id);
    }
}
