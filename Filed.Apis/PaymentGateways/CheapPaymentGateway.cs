using System.Threading.Tasks;

namespace Filed.Apis.PaymentGateways
{
    public class CheapPaymentGateway : IPaymentGateway
    {
        private readonly int _retryCount = 1;

        public async Task<bool> ProcessPayment()
        {
            return true;
        }
    }
}
