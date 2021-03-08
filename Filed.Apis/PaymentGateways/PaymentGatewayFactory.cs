using Filed.Apis.RetryPattern;
using System;

namespace Filed.Apis.PaymentGateways
{
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        RetryStrategy _retryStrategy = new RetryStrategy(1, TimeSpan.FromSeconds(2));

        public IPaymentGateway GetPaymentGateway(decimal amount)
        {
            if (amount > 500)
            {
                _retryStrategy = new RetryStrategy(3, TimeSpan.FromSeconds(2));
                return new PremiumPaymentService(_retryStrategy);
            }
            else if (amount > 20 && amount <= 500)
            {
                return new ExpensivePaymentGateway(_retryStrategy);
            }
            else
            {
                return new CheapPaymentGateway(_retryStrategy);
            }
        }
    }
}
