using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}