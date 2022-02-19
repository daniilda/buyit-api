using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.Infrastructure.Options;
using ToxiCode.BuyIt.Api.TelegramLayer;

namespace ToxiCode.BuyIt.Api.HttpControllers.Webhooks;

[ApiController]
public class WebhooksController : ControllerBase
{
    private readonly ITelegramUpdateHandler _telegramUpdateHandler;
    private readonly HttpCancellationTokenAccessor _accessor;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly TelegramOptions _options;

    public WebhooksController(
        ITelegramUpdateHandler telegramUpdateHandler,
        HttpCancellationTokenAccessor accessor,
        IOptions<TelegramOptions> options,
        ITelegramBotClient telegramBotClient)
    {
        _telegramUpdateHandler = telegramUpdateHandler;
        _accessor = accessor;
        _telegramBotClient = telegramBotClient;
        _options = options.Value;
    }

    [HttpPost]
    [Route($"{WebhooksRoutes.TelegramWebhookRoute}" + "{token}")]
    public async Task<IActionResult> PostUpdate([FromBody] Update update, string token)
    {
        if (token != _options.Token)
            return NotFound();

        if (update.Type == UpdateType.Unknown)
            return Ok();
        
        await _telegramUpdateHandler.HandleUpdateAsync(_telegramBotClient, update, _accessor.Token);
        return Ok();
    }
}