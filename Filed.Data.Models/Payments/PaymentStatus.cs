namespace Filed.Data.Models.Payments
{
    public class PaymentStatus
    {
        public int Id { get; set; }

        public long PaymentId { get; set; }

        public int StatusId { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
