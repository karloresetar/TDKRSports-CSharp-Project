using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.UseCases.PluginInterfaces.DataStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShoppingCart shoppingCart;

        public AddProductToCartUseCase(
            IProductRepository productRepository,
            IShoppingCart shoppingCart)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;
        }
        public async void Execute(int productId)
        {
            var product = productRepository.GetProduct(productId);
            await shoppingCart.AddProductAsync(product);
        }
    }
}
