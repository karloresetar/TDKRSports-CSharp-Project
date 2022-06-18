using System;
using System.Collections.Generic;
using System.Text;
using TDKRSports.CoreBusiness.Models;

namespace TDKRSports.UseCases.ViewProductScreen
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}
