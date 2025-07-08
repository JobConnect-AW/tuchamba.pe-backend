using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Aggregates;
public partial class Offer
{
    public Offer(Guid uid, string title, string description, int categoryId, float amount, string duration, string paymentMethod, string status, Guid? selectedProposalUid = null, DateTimeOffset? startAt = null, int proposalsCount = 0)
    {
        Uid = uid;
        Title = title;
        Description = description;
        CategoryId = categoryId;
        Amount = amount;
        Duration = duration;
        PaymentMethod = paymentMethod;
        Status = OfferStatus.Validate(status);
        SelectedProposalUid = selectedProposalUid;
        StartAt = startAt;
        ProposalsCount = proposalsCount;
    }

    public Offer(CreateOfferCommand command) : this(
        command.Uid,
        command.Title,
        command.Description,
        command.CategoryId,
        command.Amount,
        command.Duration,
        command.PaymentMethod,
        command.Status,
        command.SelectedProposalUid,
        command.StartAt,
        command.ProposalsCount)
    {
    }

    public void IncrementProposalsCount()
    {
        ProposalsCount++;
    }
    
    public void SetInProcess(Guid selectedProposalUid)
    {
        Status = OfferStatus.EN_PROCESO;
        SelectedProposalUid = selectedProposalUid;
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
    public Guid? SelectedProposalUid { get; private set; }
    public DateTimeOffset? StartAt { get; private set; }
    public int ProposalsCount { get; private set; }
}
