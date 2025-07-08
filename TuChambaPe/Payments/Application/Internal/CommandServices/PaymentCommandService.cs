using TuChambaPe.Payments.Domain.Model.Aggregates;
using TuChambaPe.Payments.Domain.Model.Commands;
using TuChambaPe.Payments.Domain.Repositories;
using TuChambaPe.Payments.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Payments.Application.Internal.CommandServices;

/// <summary>
///     Payment command service implementation
/// </summary>
public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork)
    : IPaymentCommandService
{
    /// <inheritdoc />
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        if (command.Amount <= 0)
            throw new ArgumentException("Payment amount must be greater than 0");

        // Verify that the offer exists (this will be handled by the foreign key constraint)
        // but we can add additional business logic here if needed

        var payment = new Payment(command);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }

    /// <inheritdoc />
    public async Task<Payment?> Handle(UpdatePaymentStatusCommand command)
    {
        var payment = await paymentRepository.FindByUidAsync(command.PaymentUid);
        if (payment is null) throw new Exception("Payment not found");

        switch (command.Status)
        {
            case TuChambaPe.Payments.Domain.Model.ValueObjects.PaymentStatus.PAID:
                payment.MarkAsPaid();
                break;
            case TuChambaPe.Payments.Domain.Model.ValueObjects.PaymentStatus.FAILED:
                payment.MarkAsFailed();
                break;
            case TuChambaPe.Payments.Domain.Model.ValueObjects.PaymentStatus.CANCELLED:
                if (!payment.CanBeCancelled())
                    throw new InvalidOperationException("Payment cannot be cancelled in its current status");
                payment.MarkAsCancelled();
                break;
            case TuChambaPe.Payments.Domain.Model.ValueObjects.PaymentStatus.REFUNDED:
                if (!payment.CanBeRefunded())
                    throw new InvalidOperationException("Payment cannot be refunded in its current status");
                payment.MarkAsRefunded();
                break;
            default:
                throw new ArgumentException($"Invalid payment status: {command.Status}");
        }

        await paymentRepository.UpdateAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }

    /// <inheritdoc />
    public async Task<Payment?> Handle(VerifyPaymentCommand command)
    {
        var payment = await paymentRepository.FindByUidAsync(command.PaymentUid);
        if (payment is null) throw new Exception("Payment not found");

        if (!payment.CanBeVerified())
            throw new InvalidOperationException("Payment cannot be verified in its current status");

        if (command.VerifiedByWorker)
            payment.VerifyByWorker();

        if (command.VerifiedByCustomer)
            payment.VerifyByCustomer();

        await paymentRepository.UpdateAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }
} 