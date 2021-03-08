namespace Filed.Apis.PaymentGateways
{
    public interface IPaymentGatewayFactory
    {
        IPaymentGateway GetPaymentGateway(decimal amount);
    }
}
