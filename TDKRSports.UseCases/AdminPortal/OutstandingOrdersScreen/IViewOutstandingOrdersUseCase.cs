using System.Collections.Generic;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}