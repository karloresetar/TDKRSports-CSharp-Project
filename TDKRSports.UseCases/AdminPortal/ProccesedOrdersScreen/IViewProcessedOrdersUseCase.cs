using System.Collections.Generic;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.AdminPortal.ProccesedOrdersScreen
{
    public interface IViewProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}