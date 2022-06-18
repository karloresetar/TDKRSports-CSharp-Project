using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.UseCases.SearchProductScreen
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SearchProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter = null)
        {
            return productRepository.GetProducts(filter);
        }
    }
}
