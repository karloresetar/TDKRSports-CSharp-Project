using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.UseCases.PluginInterfaces.StateStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.StateStore.DI
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public async Task<int> GetItemsCount()
        {
            var order = await shoppingCart.GetOrderAsync();
            if (order != null && order.LineItems != null && order.LineItems.Count > 0)
                return order.LineItems.Count;

            return 0;
        }

        public void UpdateLineItemsCount()
        {
            base.BroadCastStateChange();
        }

        public void UpdateProductQuantity()
        {
            base.BroadCastStateChange(); // broadcastamo jer kad se quantity promini minja se i count od item-a
        }
    }
}
