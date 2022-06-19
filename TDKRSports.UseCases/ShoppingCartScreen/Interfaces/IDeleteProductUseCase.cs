using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.ShoppingCartScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}