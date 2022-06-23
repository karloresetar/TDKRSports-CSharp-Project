using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.AdminPortal.OrderDetailScreen.Interfaces
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}