using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace ToxiCode.BuyIt.Api.BusinessLayer;

public interface IBuyItService
{
    Task CreateOrderAsync();
    Task AddArticlesToOrder();
}