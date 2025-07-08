using System.Threading;
using System.Threading.Tasks;
using Cortex.Mediator.Notifications;
using TuChambaPe.Proposals.Domain.Model.Events;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Offers.Domain.Model.Aggregates;

namespace TuChambaPe.Offers.Application.Internal.EventHandlers;

public class ProposalCreatedEventHandler : INotificationHandler<ProposalCreatedEvent>
{
    private readonly IOfferRepository _offerRepository;

    public ProposalCreatedEventHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task Handle(ProposalCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _offerRepository.IncrementProposalsCountAsync(notification.OfferUid);
    }
} 