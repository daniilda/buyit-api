using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;
using ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId;

public class AddReviewByItemIdHandler : AsyncRequestHandler<AddReviewByItemIdCommand>
{
    private readonly ReviewsRepository _repository;
    private readonly IMapper _mapper;

    public AddReviewByItemIdHandler(ReviewsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override Task Handle(AddReviewByItemIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = _mapper.Map<InsertReviewByItemIdCmd>(request);
        return _repository.InsertReviewByItemId(cmd, cancellationToken);
    }
}