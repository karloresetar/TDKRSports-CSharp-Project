using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.CoreBusiness.Services;
using TDKRSports.UseCases.PluginInterfaces.DataStore;
using TDKRSports.UseCases.PluginInterfaces.StateStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public PlaceOrderUseCase(
            IOrderService orderService,
            IOrderRepository orderRepository,
            IShoppingCart shoppingCart,
            IShoppingCartStateStore shoppingCartStateStore)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<string> Execute(Order order)
        {
            if (orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqueId = Guid.NewGuid().ToString();
                orderRepository.CreateOrder(order);

                await shoppingCart.EmptyAsync();
                shoppingCartStateStore.UpdateLineItemsCount();

                return order.UniqueId;

            }

            return null;
        }

    }
}
