using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace BuyIt.Api.BusinessLayer;

public interface IBuyItService
{
    Task CreateOrderAsync();
    Task AddArticlesToOrder();
}