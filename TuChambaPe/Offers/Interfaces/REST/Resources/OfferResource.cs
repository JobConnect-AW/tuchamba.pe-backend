using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Interfaces.REST.Resources;

public record OfferResource(int Id, Guid Uid, string Title, string Description, int CategoryId, float Amount, string Duration, string PaymentMethod, string Status); 