using Filed.Api.Models.Payments;
using Filed.Apis.Endpoints;
using Filed.Apis.Interfaces;
using Filed.Data.Access.DAL;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Filed.Apis.Tests
{
    public class PaymentServiceTests
    {
        private readonly Mock<IUnitOfWork> _uow;
        private readonly IPaymentService _query;

        public PaymentServiceTests()
        {
            _uow = new Mock<IUnitOfWork>();

            _query = new PaymentService(_uow.Object);
        }

        [Fact]
        public async Task ProcessPaymentShouldProcessAndSave()
        {
            var model = new ProcessPaymentModel
            {
                CreditCardNumber = "378282246310005",
                CardHolder = "Ahmad Sharif",
                SecurityCode = "123",
                ExpirationDate = DateTime.Now.AddDays(30),
                Amount = 105.05M
            };

            var result = await _query.ProcessPayment(model);

            _uow.Verify(x => x.CommitAsync());
        }
    }
}
