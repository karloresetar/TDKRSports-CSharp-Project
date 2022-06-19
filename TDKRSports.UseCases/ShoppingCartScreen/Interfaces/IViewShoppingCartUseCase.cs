using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}