using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;

public record GetFrontPageAggregationCommand() : IRequest<GetFrontPageAggregationResponse>;