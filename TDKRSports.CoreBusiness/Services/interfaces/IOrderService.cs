using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInformation(string name, string address, string city, string provice, string country, string email);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }

    
}