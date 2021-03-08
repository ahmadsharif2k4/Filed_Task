using System.Threading.Tasks;

namespace Filed.Apis.PaymentGateways
{
    public class ExpensivePaymentGateway : IPaymentGateway
    {
        private readonly int _retryCount = 1;

        public async Task<bool> ProcessPayment()
        {
            return true;
        }
    }
}
