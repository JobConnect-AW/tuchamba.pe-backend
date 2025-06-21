namespace TuChambaPe.Offers.Domain.Model.ValueObjects
{
    public enum OfferStatusEnum
    {
        NUEVA,
        EN_PROCESO,
        COMPLETADA,
        CANCELADA
    }

    public class OfferStatus
    {
        public OfferStatusEnum Status { get; }

        public OfferStatus(OfferStatusEnum status)
        {
            Status = status;
        }

        public OfferStatus(string status)
        {
            if (!Enum.TryParse(status, true, out OfferStatusEnum parsedStatus))
            {
                throw new ArgumentException($"Estado de oferta inválido: {status}");
            }
            Status = parsedStatus;
        }

        public override string ToString() => Status.ToString();
    }
}
