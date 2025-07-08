namespace TuChambaPe.Payments.Interfaces.ACL;

/// <summary>
///     Facade for the payments context
/// </summary>
public interface IPaymentsContextFacade
{
    /// <summary>
    ///     Create a payment
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <param name="offerUid">The offer UID</param>
    /// <param name="amount">The payment amount</param>
    /// <param name="currency">The payment currency</param>
    /// <returns>The UID of the created payment if successful, Guid.Empty otherwise</returns>
    Task<Guid> CreatePayment(Guid uid, Guid offerUid, decimal amount, string currency);
    
    /// <summary>
    ///     Get payment by UID
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <returns>The payment if found, null otherwise</returns>
    Task<object?> GetPaymentByUid(Guid uid);
    
    /// <summary>
    ///     Get payment by offer UID
    /// </summary>
    /// <param name="offerUid">The offer UID</param>
    /// <returns>The payment if found, null otherwise</returns>
    Task<object?> GetPaymentByOfferUid(Guid offerUid);
    
    /// <summary>
    ///     Update payment status
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <param name="status">The new status</param>
    /// <returns>True if successful, false otherwise</returns>
    Task<bool> UpdatePaymentStatus(Guid uid, string status);
    
    /// <summary>
    ///     Verify payment by worker
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <returns>True if successful, false otherwise</returns>
    Task<bool> VerifyPaymentByWorker(Guid uid);
    
    /// <summary>
    ///     Verify payment by customer
    /// </summary>
    /// <param name="uid">The payment UID</param>
    /// <returns>True if successful, false otherwise</returns>
    Task<bool> VerifyPaymentByCustomer(Guid uid);
} 