using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Commands;

public record UpdateOfferCommand(
    Guid Id,
    string Title,
    string Description,
    string Category,
    float Amount,
    string Duration,
    string PaymentMethod,
    string Status
);