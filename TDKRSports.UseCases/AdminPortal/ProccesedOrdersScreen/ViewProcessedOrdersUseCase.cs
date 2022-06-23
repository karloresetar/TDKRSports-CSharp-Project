using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.UseCases.AdminPortal.ProccesedOrdersScreen
{
    public class ViewProcessedOrdersUseCase : IViewProcessedOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewProcessedOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetProcessedOrders();
        }
    }
}
