using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Domain.Model.ValueObjects;

namespace TuChambaPe.Offers.Domain.Model.Aggregates;
public partial class Offer
{
    public Offer(Guid uid, string title, string description, string category, float amount, string duration, string paymentMethod, string status, string minimumExperience, string workSchedule, Guid userUid, int proposalsCount, Guid? selectedProposalUid, DateTimeOffset? startAt)
    {
        Uid = uid;
        Title = title;
        Description = description;
        Category = category;
        Amount = amount;
        Duration = duration;
        PaymentMethod = paymentMethod;
        Status = OfferStatus.Validate(status);
        MinimumExperience = minimumExperience;
        WorkSchedule = workSchedule;
        UserUid = userUid;
        ProposalsCount = proposalsCount;
        SelectedProposalUid = selectedProposalUid;
        StartAt = startAt;
    }

    public Offer(CreateOfferCommand command) : this(
        command.Uid,
        command.Title,
        command.Description,
        command.Category,
        command.Amount,
        command.Duration,
        command.PaymentMethod,
        command.Status,
        command.MinimumExperience,
        command.WorkSchedule,
        command.UserUid,
        command.ProposalsCount,
        command.SelectedProposalUid,
        command.StartAt)
    {
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
    public string Category { get; private set; }
    public float Amount { get; private set; }
    public string Duration { get; private set; }
    public string PaymentMethod { get; private set; }
    public string Status { get; private set; }
    public string MinimumExperience { get; private set; }
    public string WorkSchedule { get; private set; }
    public Guid UserUid { get; private set; }
    public Guid? SelectedProposalUid { get; private set; }
    public int ProposalsCount { get; private set; }
    public DateTimeOffset? StartAt { get; private set; }

    public void IncrementProposalsCount()
    {
        ProposalsCount++;
    }
}
