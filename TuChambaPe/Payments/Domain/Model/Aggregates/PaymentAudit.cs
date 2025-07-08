using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace TuChambaPe.Payments.Domain.Model.Aggregates;

/// <summary>
///     Payment audit partial class
/// </summary>
public partial class Payment : IEntityWithCreatedUpdatedDate
{
    [Column("created_at")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("updated_at")] public DateTimeOffset? UpdatedDate { get; set; }
} 