using Filed.Data.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace Filed.Data.Access.Maps
{
    public class PaymentStatusMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<PaymentStatus>()
                .ToTable("PaymentStatus").HasKey(x => x.Id);
        }
    }
}
