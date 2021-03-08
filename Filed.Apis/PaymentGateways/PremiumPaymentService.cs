using System.Threading.Tasks;

namespace Filed.Apis.PaymentGateways
{
    public class PremiumPaymentService : IPaymentGateway
    {
        private readonly int _retryCount = 3;

        public async Task<bool> ProcessPayment()
        {
            return true;
        }
    }
}
