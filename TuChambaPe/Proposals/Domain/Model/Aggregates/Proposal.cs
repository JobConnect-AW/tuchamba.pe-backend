using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Domain.Model.ValueObjects;

namespace TuChambaPe.Proposals.Domain.Model.Aggregates;

public partial class Proposal
{
    public Proposal(Guid uid, Guid workerUid, Guid customerUid, string title, string description, decimal price, string estimatedTime, string status, DateTime submittedAt)
    {
        Uid = uid;
        WorkerUid = workerUid;
        CustomerUid = customerUid;
        Title = title;
        Description = description;
        Price = price;
        EstimatedTime = estimatedTime;
        Status = ProposalStatus.Validate(status);
        SubmittedAt = submittedAt;
    }

    public Proposal(CreateProposalCommand command) : this(
        command.Uid,
        command.WorkerUid,
        command.CustomerUid,
        command.Title,
        command.Description,
        command.Price,
        command.EstimatedTime,
        command.Status,
        command.SubmittedAt)
    {
    }

    public int Id { get; private set; }
    public Guid Uid { get; private set; }
    public Guid WorkerUid { get; private set; }
    public Guid CustomerUid { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string EstimatedTime { get; private set; }
    public string Status { get; private set; }
    public DateTime SubmittedAt { get; private set; }

    public void Accept()
    {
        Status = ProposalStatus.ACCEPTED;
    }

    public void Reject()
    {
        Status = ProposalStatus.REJECTED;
    }

    public void MarkAsInProgress()
    {
        Status = ProposalStatus.IN_PROGRESS;
    }

    public void CompleteProposal()
    {
        Status = ProposalStatus.COMPLETED;
    }
} 