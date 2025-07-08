namespace TuChambaPe.Proposals.Domain.Model.ValueObjects;

/// <summary>
///     WorkerUid value object to reference the Workers bounded context
/// </summary>
public record WorkerUid
{
    /// <summary>
    ///     Constructor for WorkerUid
    /// </summary>
    /// <param name="value">The worker UID value</param>
    public WorkerUid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Worker UID cannot be empty", nameof(value));
        
        Value = value;
    }

    /// <summary>
    ///     The worker UID value
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    ///     Implicit conversion from Guid to WorkerUid
    /// </summary>
    /// <param name="value">The Guid value</param>
    public static implicit operator WorkerUid(Guid value) => new(value);

    /// <summary>
    ///     Implicit conversion from WorkerUid to Guid
    /// </summary>
    /// <param name="workerUid">The WorkerUid</param>
    public static implicit operator Guid(WorkerUid workerUid) => workerUid.Value;

    /// <summary>
    ///     ToString override
    /// </summary>
    /// <returns>String representation of the WorkerUid</returns>
    public override string ToString() => Value.ToString();
} 