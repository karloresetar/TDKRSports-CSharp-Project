using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.CoreBusiness.Services
{
    public class OrderService
    {

        public bool ValidateCustomerInformation(
                string name,
                string address,
                string city,
                string provice,
                string country)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(provice) ||
                string.IsNullOrWhiteSpace(country)) return false;
            
            return true;                    
        }

        public bool ValidateCreateOrder(Order order)
        {
            //order has to existi
            if (order == null) return false;

            //order has to have order line items
            if (order.LineItems == null || order.LineItems.Count <= 0) return false;


            //validating line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Price < 0 ||
                    item.Quantity <= 0) return false;
            }

            //validate customer info
            if (!ValidateCustomerInformation(order.CustomerName,
                    order.CustomerAddress,
                    order.CustomerCity,
                    order.CustomerStateProvince,
                    order.CustomerCountry)) return false;

            return true;
        }
    }
}
