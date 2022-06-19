using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;
using TDKRSports.UseCases.PluginInterfaces.UI;

namespace TDKRSports.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {

        private const string cstrShoppingCart = "TDKRSports.ShoppingCart";
        private readonly IJSRuntime jSRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jSRuntime, IProductRepository productRepository)
        {
            this.jSRuntime = jSRuntime;
            this.productRepository = productRepository;
        }

        public Task<Order> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task EmptyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        private async Task<Order> GetOrder()//Async jer radimo za jsruntime
        {
            Order order = null;

            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if(!string.IsNullOrWhiteSpace(strOrder))
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = productRepository.GetProduct(item.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem",cstrShoppingCart,JsonConvert.SerializeObject(order));
        }
    }
}
