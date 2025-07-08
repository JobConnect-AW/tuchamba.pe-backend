using System.Threading;
using System.Threading.Tasks;
using Cortex.Mediator.Notifications;
using TuChambaPe.Proposals.Domain.Model.Events;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Offers.Domain.Model.Aggregates;

namespace TuChambaPe.Offers.Application.Internal.EventHandlers;

public class ProposalAcceptedEventHandler : INotificationHandler<ProposalAcceptedEvent>
{
    private readonly IOfferRepository _offerRepository;

    public ProposalAcceptedEventHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task Handle(ProposalAcceptedEvent notification, CancellationToken cancellationToken)
    {
        await _offerRepository.SetInProcessAsync(notification.OfferUid, notification.ProposalUid);
    }
} 