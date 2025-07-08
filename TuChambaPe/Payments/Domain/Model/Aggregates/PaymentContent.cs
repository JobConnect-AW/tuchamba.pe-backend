using TuChambaPe.Payments.Domain.Model.ValueObjects;

namespace TuChambaPe.Payments.Domain.Model.Aggregates;

/// <summary>
///     Payment content partial class
/// </summary>
public partial class Payment
{
    /// <summary>
    ///     Mark payment as paid
    /// </summary>
    public void MarkAsPaid()
    {
        Status = PaymentStatus.PAID;
    }

    /// <summary>
    ///     Mark payment as failed
    /// </summary>
    public void MarkAsFailed()
    {
        Status = PaymentStatus.FAILED;
    }

    /// <summary>
    ///     Mark payment as cancelled
    /// </summary>
    public void MarkAsCancelled()
    {
        Status = PaymentStatus.CANCELLED;
    }

    /// <summary>
    ///     Mark payment as refunded
    /// </summary>
    public void MarkAsRefunded()
    {
        Status = PaymentStatus.REFUNDED;
    }

    /// <summary>
    ///     Verify payment by worker
    /// </summary>
    public void VerifyByWorker()
    {
        WorkerVerified = true;
    }

    /// <summary>
    ///     Verify payment by customer
    /// </summary>
    public void VerifyByCustomer()
    {
        CustomerVerified = true;
    }

    /// <summary>
    ///     Update payment amount
    /// </summary>
    /// <param name="amount">The new amount</param>
    public void UpdateAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0", nameof(amount));
        
        Amount = amount;
    }

    /// <summary>
    ///     Check if payment is completed (paid and verified by both parties)
    /// </summary>
    /// <returns>True if payment is completed, false otherwise</returns>
    public bool IsCompleted()
    {
        return Status == PaymentStatus.PAID && WorkerVerified && CustomerVerified;
    }

    /// <summary>
    ///     Check if payment can be verified
    /// </summary>
    /// <returns>True if payment can be verified, false otherwise</returns>
    public bool CanBeVerified()
    {
        return Status == PaymentStatus.PAID;
    }

    /// <summary>
    ///     Check if payment can be refunded
    /// </summary>
    /// <returns>True if payment can be refunded, false otherwise</returns>
    public bool CanBeRefunded()
    {
        return Status == PaymentStatus.PAID && !IsCompleted();
    }

    /// <summary>
    ///     Check if payment can be cancelled
    /// </summary>
    /// <returns>True if payment can be cancelled, false otherwise</returns>
    public bool CanBeCancelled()
    {
        return Status == PaymentStatus.PENDING;
    }
} 