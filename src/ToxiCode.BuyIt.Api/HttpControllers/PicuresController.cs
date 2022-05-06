using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Handlers.Pictures.AddPictures.Dtos;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("v1/[controller]")]
public class PicturesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PicturesController(IMediator mediator) 
        => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<AddPicturesResponse>> UploadPictures([FromForm] AddPicturesCommand command) 
        => Ok(await _mediator.Send(command));
}