using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.Commands;

namespace TuChambaPe.Payments.Domain.Services;

/// <summary>
///     Payment command service interface
/// </summary>
public interface IPaymentCommandService
{
    /// <summary>
    ///     Handle create payment command
    /// </summary>
    /// <param name="command">The create payment command</param>
    /// <returns>The created payment</returns>
    Task<Payment?> Handle(CreatePaymentCommand command);

    /// <summary>
    ///     Handle update payment status command
    /// </summary>
    /// <param name="command">The update payment status command</param>
    /// <returns>The updated payment</returns>
    Task<Payment?> Handle(UpdatePaymentStatusCommand command);

    /// <summary>
    ///     Handle verify payment command
    /// </summary>
    /// <param name="command">The verify payment command</param>
    /// <returns>The verified payment</returns>
    Task<Payment?> Handle(VerifyPaymentCommand command);
} 