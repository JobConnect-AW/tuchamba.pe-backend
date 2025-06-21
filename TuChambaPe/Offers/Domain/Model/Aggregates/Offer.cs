using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Aggregates;
public partial class Offer
{
    public Offer(Guid uid, string title, string description, int categoryId, float amount, string duration, string paymentMethod, string status)
    {
        Uid = uid;
        Title = title;
        Description = description;
        CategoryId = categoryId;
        Amount = amount;
        Duration = duration;
        PaymentMethod = paymentMethod;
        Status = OfferStatus.Validate(status);
    }

    public Offer(CreateOfferCommand command) : this(
        command.Uid,
        command.Title,
        command.Description,
        command.CategoryId,
        command.Amount,
        command.Duration,
        command.PaymentMethod,
        command.Status)
    {
    }

    public int Id { get; }
    public Guid Uid { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CategoryId { get; private set; }
    public float Amount { get; private set; }
    public string Duration { get; private set; }
    public string PaymentMethod { get; private set; }
    public string Status { get; private set; }
}
