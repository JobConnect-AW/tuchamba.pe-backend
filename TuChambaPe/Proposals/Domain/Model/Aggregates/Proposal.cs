using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Domain.Model;

namespace TuChambaPe.Proposals.Domain.Model.Aggregates;

public partial class Proposal
{
    public Proposal(Guid uid, ValueObjects.OfferUid offerUid, ValueObjects.WorkerUid workerUid, string message, decimal price, DateTime createdAt, DateTime? updatedAt = null, string? createdBy = null, string? updatedBy = null, string status = null)
    {
        Uid = uid;
        OfferUid = offerUid;
        WorkerUid = workerUid;
        Message = message;
        Price = price;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        Status = status ?? ValueObjects.ProposalStatus.SUBMITTED;
    }

    public int Id { get; private set; }
    public Guid Uid { get; private set; }
    public ValueObjects.OfferUid OfferUid { get; private set; }
    public ValueObjects.WorkerUid WorkerUid { get; private set; }
    public string Message { get; private set; }
    public decimal Price { get; private set; }
    public string Status { get; private set; }
    // Auditoría
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public string? CreatedBy { get; private set; }
    public string? UpdatedBy { get; private set; }
} 