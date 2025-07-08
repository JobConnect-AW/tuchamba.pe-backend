namespace TuChambaPe.Payments.Domain.Model.ValueObjects;

/// <summary>
///     Currency value object
/// </summary>
public static class Currency
{
    public const string PEN = "PEN";
    public const string USD = "USD";
    public const string EUR = "EUR";

    public static readonly string[] ValidCurrencies = { PEN, USD, EUR };

    public static bool IsValid(string currency)
    {
        return ValidCurrencies.Contains(currency?.ToUpper());
    }

    public static string Validate(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("La moneda no puede estar vacía");

        var upperCurrency = currency.ToUpper();
        if (!IsValid(upperCurrency))
            throw new ArgumentException($"Moneda inválida: {currency}. Monedas válidas: {string.Join(", ", ValidCurrencies)}");

        return upperCurrency;
    }
} 