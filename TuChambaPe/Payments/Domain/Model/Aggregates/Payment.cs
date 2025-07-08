using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Model.Aggregates;

/// <summary>
///     Payment aggregate root entity
/// </summary>
/// <remarks>
///     This class is used to represent a payment in the application.
/// </remarks>
public partial class Payment
{
    /// <summary>
    ///     Default constructor for the payment entity
    /// </summary>
    /// <param name="uid">The unique identifier for the payment</param>
    /// <param name="offerId">The offer ID for the payment</param>
    /// <param name="amount">The payment amount</param>
    /// <param name="currency">The payment currency</param>
    /// <param name="status">The payment status</param>
    public Payment(Guid uid, OfferUid offerUid, decimal amount, string currency, string status) : this()
    {
        Uid = uid;
        OfferUid = offerUid;
        Amount = amount;
        Currency = currency;
        Status = status;
        WorkerVerified = false;
        CustomerVerified = false;
    }

    /// <summary>
    ///     Constructor from CreatePaymentCommand
    /// </summary>
    /// <param name="command">The create payment command</param>
    public Payment(CreatePaymentCommand command) : this(
        command.Uid,
        command.OfferUid,
        command.Amount,
        command.Currency,
        PaymentStatus.PENDING)
    {
    }

    /// <summary>
    ///     Default constructor for EF Core
    /// </summary>
    public Payment()
    {
        WorkerVerified = false;
        CustomerVerified = false;
    }

    public int Id { get; }
    public Guid Uid { get; private set; }
    public OfferUid OfferUid { get; private set; }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }
    public string Status { get; private set; }
    public bool WorkerVerified { get; private set; }
    public bool CustomerVerified { get; private set; }
    

} 