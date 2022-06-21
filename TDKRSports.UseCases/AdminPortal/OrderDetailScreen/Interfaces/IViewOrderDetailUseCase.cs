using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.AdminPortal.OrderDetailScreen.Interfaces
{
    internal interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}