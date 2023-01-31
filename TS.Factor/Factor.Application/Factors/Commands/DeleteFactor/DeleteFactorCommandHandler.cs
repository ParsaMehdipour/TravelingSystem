using Factor.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Factor.Application.Factors.Commands.DeleteFactor;

public class DeleteFactorCommandHandler : IRequestHandler<DeleteFactorCommand, Result>
{
    protected IFactorRepository _factorRepository { get; }

    public DeleteFactorCommandHandler(IFactorRepository factorRepository)
    {
        _factorRepository = factorRepository;
    }

    public async Task<Result> Handle(DeleteFactorCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Factor factor = await _factorRepository.GetWithoutQueryFilterAsync(_ => _.Id == request.Id, cancellationToken);

        ArgumentNullException.ThrowIfNull(factor);

        if (request.IsRestore)
            factor.RestoreItem();
        else
            factor.DeleteItem();

        _factorRepository.Update(factor);
        await _factorRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
