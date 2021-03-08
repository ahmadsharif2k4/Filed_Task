using Filed.Data.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace Filed.Data.Access.Maps
{
    public class PaymentMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Payment>()
                .ToTable("Payments").HasKey(x => x.Id);
        }
    }
}
