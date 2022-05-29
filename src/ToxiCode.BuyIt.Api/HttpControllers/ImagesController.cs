using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Handlers.Images.UploadImages.Dtos;
using ToxiCode.BuyIt.Api.Platform;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImagesController(IMediator mediator) 
        => _mediator = mediator;

    [HttpPost]
    [TokenAuthenticationFilter]
    public async Task<ActionResult<AddImagesResponse>> UploadImages([FromForm] AddImagesCommand command) 
        => Ok(await _mediator.Send(command));
}