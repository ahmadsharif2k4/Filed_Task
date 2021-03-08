using Filed.Api.Models.Payments;
using Filed.Apis.Interfaces;
using Filed.Apis.PaymentGateways;
using Filed.Apis.RetryPattern;
using Filed.Common.Enums;
using Filed.Common.Exceptions;
using Filed.Data.Access.DAL;
using Filed.Data.Models.Payments;
using System;
using System.Threading.Tasks;

namespace Filed.Apis.Endpoints
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _uow;

        public PaymentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> ProcessPayment(ProcessPaymentModel model)
        {
            try
            {
                //Adding Payment
                var payment = new Payment
                {
                    CreditCardNumber = model.CreditCardNumber,
                    CardHolder = model.CardHolder,
                    ExpirationDate = model.ExpirationDate,
                    SecurityCode = model.SecurityCode,
                    Amount = model.Amount
                };
                _uow.Add(payment);
                await _uow.CommitAsync();

                //Adding Payment Status as Initial - Pending
                var paymentStatus = new PaymentStatus
                {
                    PaymentId = payment.Id,
                    StatusId = (int)TransactionStatus.Pending
                };
                _uow.Add(paymentStatus);

                paymentStatus = new PaymentStatus()
                {
                    PaymentId = payment.Id
                };

                var factory = new PaymentGatewayFactory();
                IPaymentGateway paymentGateway = factory.GetPaymentGateway(model.Amount);

                if (await paymentGateway.ProcessPayment())
                    paymentStatus.StatusId = (int)TransactionStatus.Processed;
                else
                    paymentStatus.StatusId = (int)TransactionStatus.Failed;

                _uow.Add(paymentStatus);
                await _uow.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
