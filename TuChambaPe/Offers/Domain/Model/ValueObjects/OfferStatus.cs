namespace TuChambaPe.Offers.Domain.Model.ValueObjects
{
    public static class OfferStatus
    {
        public const string NUEVA = "NUEVA";
        public const string EN_PROCESO = "EN_PROCESO";
        public const string COMPLETADA = "COMPLETADA";
        public const string CANCELADA = "CANCELADA";

        public static readonly string[] ValidStatuses = { NUEVA, EN_PROCESO, COMPLETADA, CANCELADA };

        public static bool IsValid(string status)
        {
            return ValidStatuses.Contains(status?.ToUpper());
        }

        public static string Validate(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El estado de la oferta no puede estar vacío");

            var upperStatus = status.ToUpper();
            if (!IsValid(upperStatus))
                throw new ArgumentException($"Estado de oferta inválido: {status}. Estados válidos: {string.Join(", ", ValidStatuses)}");

            return upperStatus;
        }
    }
}
