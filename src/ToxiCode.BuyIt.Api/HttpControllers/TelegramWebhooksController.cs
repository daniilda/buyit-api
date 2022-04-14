// TODO: When use uncomment
// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using Telegram.Bot;
// using Telegram.Bot.Types;
// using Telegram.Bot.Types.Enums;
// using ToxiCode.BuyIt.Api.Common;
// using ToxiCode.BuyIt.Api.TelegramLayer.Options;
//
// namespace ToxiCode.BuyIt.Api.TelegramLayer.HttpWebhooksControllers;
//
// [ApiController]
// public class TelegramWebhooksController : ControllerBase
// {
//     private readonly ITelegramUpdateHandler _telegramUpdateHandler;
//     private readonly HttpCancellationTokenAccessor _accessor;
//     private readonly ITelegramBotClient _telegramBotClient;
//     private readonly TelegramOptions _options;
//
//     public TelegramWebhooksController(
//         ITelegramUpdateHandler telegramUpdateHandler,
//         HttpCancellationTokenAccessor accessor,
//         IOptions<TelegramOptions> options,
//         ITelegramBotClient telegramBotClient)
//     {
//         _telegramUpdateHandler = telegramUpdateHandler;
//         _accessor = accessor;
//         _telegramBotClient = telegramBotClient;
//         _options = options.Value;
//     }
//
//     [HttpPost]
//     [Route($"{WebhooksRoutes.TelegramWebhookRoute}" + "{token}")]
//     public async Task<IActionResult> PostUpdate([FromBody] Update update, string token)
//     {
//         if (token != _options.Token)
//             return NotFound();
//
//         if (update.Type == UpdateType.Unknown)
//             return Ok();
//         
//         await _telegramUpdateHandler.HandleUpdateAsync(_telegramBotClient, update, _accessor.Token);
//         return Ok();
//     }
// }