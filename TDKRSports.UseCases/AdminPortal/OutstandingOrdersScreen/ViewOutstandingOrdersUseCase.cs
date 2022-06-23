using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutstandingOrders();
        }
    }
}
