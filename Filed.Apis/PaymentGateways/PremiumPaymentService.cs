using Filed.Apis.RetryPattern;
using System.Threading.Tasks;

namespace Filed.Apis.PaymentGateways
{
    public class PremiumPaymentService : IPaymentGateway
    {
        private readonly RetryExecutor _retryExecutor;

        public PremiumPaymentService(RetryStrategy retryStrategy)
        {
            _retryExecutor = new RetryExecutor(retryStrategy);
        }


        public async Task<bool> ProcessPayment()
        {
            _retryExecutor.Retry(
                () =>
                {
                    //external logic will be here...
                });

            return true;
        }
    }
}
