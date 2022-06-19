using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public Task<Order> Execute()// uzimamo order objekt iz kosarice
        {
            return shoppingCart.GetOrderAsync();
        }
    }
}
