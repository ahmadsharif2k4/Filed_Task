using Filed.Api.Models.Payments;
using System.Threading.Tasks;

namespace Filed.Apis.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(ProcessPaymentModel model);
    }
}
