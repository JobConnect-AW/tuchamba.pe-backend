using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Commands;

public record CreateOfferCommand(
    Guid Uid,
    string Title,
    string Description,
    int CategoryId,
    float Amount,
    string Duration,
    string PaymentMethod,
    string Status
);