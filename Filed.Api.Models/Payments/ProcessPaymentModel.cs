using Filed.Api.Models.CustomAttributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Filed.Api.Models.Payments
{
    public class ProcessPaymentModel
    {
        [JsonProperty(PropertyName = "CreditCardNumber ")]
        [Required, CreditCard]
        public string CreditCardNumber { get; set; }


        [JsonProperty(PropertyName = "CardHolder")]
        [Required]
        public string CardHolder { get; set; }

        [JsonProperty(PropertyName = "ExpirationDate ")]
        [Required]
        [CheckDateRangeAttribute]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "SecurityCode ")]
        [MaxLength(3)]
        public string SecurityCode { get; set; }

        [JsonProperty(PropertyName = "Amount ")]
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

    }
}
