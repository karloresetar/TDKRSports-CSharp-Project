using System.Collections.Generic;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.AdminPortal.OutstandingOrdersScreen
{
    internal interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}