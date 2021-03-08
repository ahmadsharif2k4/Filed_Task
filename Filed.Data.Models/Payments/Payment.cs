using System;
using System.Collections.Generic;

namespace Filed.Data.Models.Payments
{
    public class Payment
    {
        public Payment()
        {
            this.Statuses = new HashSet<PaymentStatus>();
        }

        public long Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public virtual ICollection<PaymentStatus> Statuses { get; set; }
    }
}
