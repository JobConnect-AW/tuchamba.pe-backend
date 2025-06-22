using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.Commands;

namespace TuChambaPe.Offers.Domain.Services;

public interface IOfferCommandService
{
    Task<Offer> Handle(CreateOfferCommand command);
    Task Handle(UpdateOfferCommand command);
    Task Handle(DeleteOfferCommand command);
} 