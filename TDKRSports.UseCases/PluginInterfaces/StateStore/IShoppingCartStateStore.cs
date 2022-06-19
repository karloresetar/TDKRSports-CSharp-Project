using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TDKRSports.UseCases.PluginInterfaces.StateStore
{
    public interface IShoppingCartStateStore : IStateStore
    {
        Task<int> GetItemsCount(); // za gettanje stanja 
        void UpdateLineItemsCount();
        void UpdateProductQuantity();


    }
}
