namespace TuChambaPe.Payments.Domain.Model.ValueObjects;

/// <summary>
///     OfferUid value object to reference the Offers bounded context
/// </summary>
public record OfferUid
{
    /// <summary>
    ///     Constructor for OfferUid
    /// </summary>
    /// <param name="value">The offer UID value</param>
    public OfferUid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Offer UID cannot be empty", nameof(value));
        
        Value = value;
    }

    /// <summary>
    ///     The offer UID value
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    ///     Implicit conversion from Guid to OfferUid
    /// </summary>
    /// <param name="value">The Guid value</param>
    public static implicit operator OfferUid(Guid value) => new(value);

    /// <summary>
    ///     Implicit conversion from OfferUid to Guid
    /// </summary>
    /// <param name="offerUid">The OfferUid</param>
    public static implicit operator Guid(OfferUid offerUid) => offerUid.Value;

    /// <summary>
    ///     ToString override
    /// </summary>
    /// <returns>String representation of the OfferUid</returns>
    public override string ToString() => Value.ToString();
} 