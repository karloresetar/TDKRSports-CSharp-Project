using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public interface IPlaceOrderUseCase
    {
        Task<string> Execute(Order order);
    }
}