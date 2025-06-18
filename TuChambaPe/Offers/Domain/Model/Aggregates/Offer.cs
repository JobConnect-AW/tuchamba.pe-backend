using TuChambaPe.Publishing.Domain.Model.Commands;
using TuChambaPe.Publishing.Domain.Model.Entities;

namespace TuChambaPe.Publishing.Domain.Model.Aggregate;

public enum OfferStatus
{
    NUEVA,
    EN_PROCESO,
    COMPLETADA,
    CANCELADA
}

public partial class Offer
{
    public Offer(string id, string title, string description, int categoryId, float amount, string duration, string paymentMethod, OfferStatus status) : this()
    {
        Id = id;
        Title = title;
        Description = description;
        CategoryId = categoryId;
        Amount = amount;
        Duration = duration;
        PaymentMethod = paymentMethod;
        Status = status;
    }

    public Offer(CreateOfferCommand command) : this(
        command.Title,
        command.Description,
        command.CategoryId,
        command.Amount,
        command.Duration,
        command.PaymentMethod,
        command.Status)
    {
    }

    public string Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CategoryId { get; private set; }
    public float Amount { get; private set; }
    public string Duration { get; private set; }
    public string PaymentMethod { get; private set; }
    public OfferStatus Status { get; private set; }
}
