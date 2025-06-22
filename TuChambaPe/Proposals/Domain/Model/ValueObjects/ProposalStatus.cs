namespace TuChambaPe.Proposals.Domain.Model.ValueObjects
{
    public static class ProposalStatus
    {
        public const string SUBMITTED = "SUBMITTED";
        public const string ACCEPTED = "ACCEPTED";
        public const string REJECTED = "REJECTED";
        public const string IN_PROGRESS = "IN_PROGRESS";
        public const string COMPLETED = "COMPLETED";

        public static readonly string[] ValidStatuses = { SUBMITTED, ACCEPTED, REJECTED, IN_PROGRESS, COMPLETED };

        public static bool IsValid(string status)
        {
            return ValidStatuses.Contains(status?.ToUpper());
        }

        public static string Validate(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El estado de la propuesta no puede estar vacío");

            var upperStatus = status.ToUpper();
            if (!IsValid(upperStatus))
                throw new ArgumentException($"Estado de propuesta inválido: {status}. Estados válidos: {string.Join(", ", ValidStatuses)}");

            return upperStatus;
        }
    }
} 