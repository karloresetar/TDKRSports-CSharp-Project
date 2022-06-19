using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.StateStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public UpdateQuantityUseCase(IShoppingCart shoppingCart,
            IShoppingCartStateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }
        public async Task<Order> Execute(int productId, int quantity)
        {
            var order = await shoppingCart.UpdateQuantityAsync(productId, quantity);
            shoppingCartStateStore.UpdateProductQuantity();
            return order;
        }
    }
}
