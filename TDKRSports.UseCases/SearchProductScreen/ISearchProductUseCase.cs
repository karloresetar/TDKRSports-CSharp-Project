using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.SearchProductScreen
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}
