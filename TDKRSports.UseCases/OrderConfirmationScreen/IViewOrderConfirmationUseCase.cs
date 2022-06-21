using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}