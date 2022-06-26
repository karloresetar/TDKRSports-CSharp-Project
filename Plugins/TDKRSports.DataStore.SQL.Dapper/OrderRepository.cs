using System;
using System.Collections.Generic;
using System.Linq;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.Dapper;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.DataStore.SQL.Dapper
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDataAccess dataAccess;

        public OrderRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public int CreateOrder(Order order)
        {
            var sqlOrderString = @"INSERT INTO Orders 
                            (DatePlaced, DateProcessing, DateProcessed,
                            CustomerName, CustomerAddress, CustomerCity, CustomerStateProvince, 
                            CustomerCountry, CustomerEmail, AdminUser, UniqueId)
                            OUTPUT INSERTED.OrderId
                            VALUES 
                            (@DatePlaced, @DateProcessing, @DateProcessed,
                            @CustomerName, @CustomerAddress, @CustomerCity, @CustomerStateProvince, 
                            @CustomerCountry, @CustomerEmail, @AdminUser, @UniqueId)";
            var orderId = dataAccess.QuerySingle<int, Order>(sqlOrderString, order);
            var sqlOrderLineItemString = @"INSERT INTO OrderLineItems 
                            (ProductId, Price, Quantity, OrderId)
                            VALUES (@ProductId, @Price, @Quantity, @OrderId)";
            order.LineItems.ForEach(x => x.OrderId = orderId);
            dataAccess.Execute(sqlOrderLineItemString, order.LineItems);
            return orderId;
        }
        
        public IEnumerable<Order> GetOrders()
        {
            return dataAccess.Query<Order, dynamic>("SELECT * FROM Orders", new { });
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var sql = "SELECT * FROM Orders WHERE DateProcessed is null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var sql = "SELECT * FROM Orders WHERE DateProcessed is not null";
            return dataAccess.Query<Order, dynamic>(sql, new { });
        }

        public Order GetOrder(int id)
        {
            var sqlString = "SELECT * FROM Orders WHERE OrderId = @OrderId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sqlString, new {OrderId = id});
            order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
            return order;
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            var sqlString = "SELECT * FROM Orders WHERE UniqueId = @UniqueId";
            var order = dataAccess.QuerySingle<Order, dynamic>(sqlString, new { UniqueId = uniqueId });
            order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
            return order;
        }

        public void UpdateOrder(Order order)
        {
            var sqlOrderString = @"UPDATE Orders
                                SET DatePlaced = @DatePlaced
                                ,DateProcessing = @DateProcessing
                                ,DateProcessed = @DateProcessed
                                ,CustomerName = @CustomerName
                                ,CustomerAddress = @CustomerAddress
                                ,CustomerCity = @CustomerCity
                                ,CustomerStateProvince = @CustomerStateProvince
                                ,CustomerCountry = @CustomerCountry
                                ,AdminUser = @AdminUser
                                ,UniqueId = @UniqueId
                                WHERE OrderId = @OrderId";
            dataAccess.Execute<Order>(sqlOrderString, order);
            var sqlOrderLineItemString = @"UPDATE OrderLineItems
                                        SET ProductId = @ProductId
                                        ,OrderId = @OrderId
                                        ,Quantity = @Quantity
                                        ,Price = @Price
                                        WHERE LineItemId = @LineItemId)";
            dataAccess.Execute<List<OrderLineItem>>(sqlOrderLineItemString, order.LineItems);
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var sql = "SELECT * FROM OrderLineItems WHERE OrderId = @OrderId";
            var lineItems = dataAccess.Query<OrderLineItem, dynamic>(sql, new { OrderId = orderId });

            sql = "SELECT * FROM Products WHERE ProductId = @ProductId";
            lineItems.ForEach(x => x.Product = dataAccess.QuerySingle<Product, dynamic>(sql, new { ProductId = x.ProductId }));

            return lineItems;
        }
    }
}
