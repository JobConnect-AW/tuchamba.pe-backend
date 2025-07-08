using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Model.Commands;

namespace TuChambaPe.Proposals.Domain.Services;

public interface IProposalCommandService
{
    Task<Proposal> Handle(CreateProposalCommand command);
    Task Handle(UpdateProposalCommand command);
    Task Handle(DeleteProposalCommand command);
} 