namespace TuChambaPe.Payments.Domain.Model.ValueObjects;

/// <summary>
///     Payment status value object
/// </summary>
public static class PaymentStatus
{
    public const string PENDING = "PENDING";
    public const string PAID = "PAID";
    public const string FAILED = "FAILED";
    public const string CANCELLED = "CANCELLED";
    public const string REFUNDED = "REFUNDED";

    public static readonly string[] ValidStatuses = { PENDING, PAID, FAILED, CANCELLED, REFUNDED };

    public static bool IsValid(string status)
    {
        return ValidStatuses.Contains(status?.ToUpper());
    }

    public static string Validate(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("El estado del pago no puede estar vacío");

        var upperStatus = status.ToUpper();
        if (!IsValid(upperStatus))
            throw new ArgumentException($"Estado de pago inválido: {status}. Estados válidos: {string.Join(", ", ValidStatuses)}");

        return upperStatus;
    }
} 