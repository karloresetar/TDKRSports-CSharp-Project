using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.UseCases.AdminPortal.OrderDetailScreen
{
    public class ViewOrderDetailUseCase : IViewOrderDetailUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrderDetailUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Order Execute(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
