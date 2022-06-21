namespace TDKRSports.UseCases.AdminPortal.OrderDetailScreen.Interfaces
{
    internal interface IProcessOrderUseCase
    {
        bool Execute(int orderId, string adminUserName);
    }
}