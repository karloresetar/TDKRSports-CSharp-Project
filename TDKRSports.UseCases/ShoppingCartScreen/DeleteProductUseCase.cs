using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.StateStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
            
        }
        public async Task<Order> Execute(int productId)
        {
            var order = await this.shoppingCart.DeleteProductAsync(productId);
            this.shoppingCartStateStore.UpdateLineItemsCount();

            return order;
        }
    }
}
