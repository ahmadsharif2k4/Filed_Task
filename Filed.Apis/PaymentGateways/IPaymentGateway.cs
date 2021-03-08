using System.Threading.Tasks;

namespace Filed.Apis.PaymentGateways
{
    public interface IPaymentGateway
    {
        Task<bool> ProcessPayment();
    }
}
