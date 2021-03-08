namespace Filed.Apis.PaymentGateways
{
    public class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        public IPaymentGateway GetPaymentGateway(decimal amount)
        {
            if (amount > 500)
            {
                return new PremiumPaymentService();
            }
            else if (amount > 20 && amount <= 500)
            {
                return new ExpensivePaymentGateway();
            }
            else
            {
                return new CheapPaymentGateway();
            }
        }
    }
}
