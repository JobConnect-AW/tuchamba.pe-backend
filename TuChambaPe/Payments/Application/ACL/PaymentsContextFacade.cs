using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Domain.Model.Queries;
using TuChambaPe.Payments.Domain.Model.ValueObjects;
using TuChambaPe.Payments.Domain.Services;
using TuChambaPe.Payments.Interfaces.ACL;

namespace TuChambaPe.Payments.Application.ACL;

/// <summary>
///     Facade for the payments context
/// </summary>
/// <param name="paymentCommandService">The payment command service</param>
/// <param name="paymentQueryService">The payment query service</param>
public class PaymentsContextFacade(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService
) : IPaymentsContextFacade
{
    /// <inheritdoc />
    public async Task<Guid> CreatePayment(Guid uid, Guid offerUid, decimal amount, string currency)
    {
        var createPaymentCommand = new CreatePaymentCommand(uid, new OfferUid(offerUid), amount, currency);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        return payment?.Uid ?? Guid.Empty;
    }

    /// <inheritdoc />
    public async Task<object?> GetPaymentByUid(Guid uid)
    {
        var getPaymentByUidQuery = new GetPaymentByUidQuery(uid);
        return await paymentQueryService.Handle(getPaymentByUidQuery);
    }

    /// <inheritdoc />
    public async Task<object?> GetPaymentByOfferUid(Guid offerUid)
    {
        var getPaymentsByOfferUidQuery = new GetPaymentsByOfferUidQuery(new OfferUid(offerUid));
        var payments = await paymentQueryService.Handle(getPaymentsByOfferUidQuery);
        return payments.FirstOrDefault();
    }

    /// <inheritdoc />
    public async Task<bool> UpdatePaymentStatus(Guid uid, string status)
    {
        var updatePaymentStatusCommand = new UpdatePaymentStatusCommand(uid, status);
        var payment = await paymentCommandService.Handle(updatePaymentStatusCommand);
        return payment != null;
    }

    /// <inheritdoc />
    public async Task<bool> VerifyPaymentByWorker(Guid uid)
    {
        var verifyPaymentCommand = new VerifyPaymentCommand(uid, true, false);
        var payment = await paymentCommandService.Handle(verifyPaymentCommand);
        return payment != null;
    }

    /// <inheritdoc />
    public async Task<bool> VerifyPaymentByCustomer(Guid uid)
    {
        var verifyPaymentCommand = new VerifyPaymentCommand(uid, false, true);
        var payment = await paymentCommandService.Handle(verifyPaymentCommand);
        return payment != null;
    }
} 