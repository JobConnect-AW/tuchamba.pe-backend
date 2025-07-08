using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.Queries;
using TuChambaPe.Payments.Domain.Repositories;
using TuChambaPe.Payments.Domain.Services;

namespace TuChambaPe.Payments.Application.Internal.QueryServices;

/// <summary>
///     Payment query service implementation
/// </summary>
public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
    /// <inheritdoc />
    public async Task<Payment?> Handle(GetPaymentByUidQuery query)
    {
        return await paymentRepository.FindByUidAsync(query.PaymentUid);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Payment>> Handle(GetPaymentsByOfferUidQuery query)
    {
        return await paymentRepository.FindByOfferUidAsync(query.OfferUid);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }
} 