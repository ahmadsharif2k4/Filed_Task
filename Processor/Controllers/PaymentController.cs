using Filed.Api.Models.Payments;
using Filed.Apis.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Processor.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Processor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _service;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService service)
        {
            _logger = logger;
            _service = service;
        }

        
        [HttpPost, Route("ProcessPayment")]
        [ValidateModel]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentModel processPaymentModel)
        {
            try
            {
                await _service.ProcessPayment(processPaymentModel);
                return Ok("Payment is processed");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }
}
