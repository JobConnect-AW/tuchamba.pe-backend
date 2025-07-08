using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Commands;

public record CreateOfferCommand(
    Guid Uid,
    string Title,
    string Description,
    string Category,
    float Amount,
    string Duration,
    string PaymentMethod,
    string Status,
    string MinimumExperience,
    string WorkSchedule,
    Guid UserUid
);