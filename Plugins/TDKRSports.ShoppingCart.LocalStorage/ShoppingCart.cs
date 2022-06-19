using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public Task EmptyAsync()
        {
            return this.SetOrder(null); // ostat ce u istom key-u stavit ce null u local storage {cstrShoppingCart} (a to je lose stavit null za key) popravit cemo u GetOrderu tkd.
                                        // dodamo && strOrder.ToLower() != "null"
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await this.SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrder();
            if (quantity < 0)
                return order;
            else if(quantity == 0)
                return await DeleteProductAsync(productId);
            
            var lineItem = order.LineItems.SingleOrDefault(x => x.ProductId == productId);
            if(lineItem != null) lineItem.Quantity = quantity;
            await SetOrder(order);

            return order;

        }

        private async Task<Order> GetOrder()//Async jer radimo za jsruntime
        {
            Order order = null;

            var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if(!string.IsNullOrWhiteSpace(strOrder) && strOrder.ToLower() != "null")
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
