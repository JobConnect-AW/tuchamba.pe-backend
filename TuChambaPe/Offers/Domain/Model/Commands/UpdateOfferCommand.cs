using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Commands;

public record UpdateOfferCommand(
    string Id,
    string Title,
    string Description,
    int CategoryId,
    float Amount,
    string Duration,
    string PaymentMethod,
    OfferStatus Status
);