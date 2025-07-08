using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Interfaces.REST.Resources;

public record CreateOfferResource(
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