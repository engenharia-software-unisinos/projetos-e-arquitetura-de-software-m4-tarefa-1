using Microsoft.AspNetCore.Mvc;
using SE.PaymentAPI.Models;
using SE.PaymentAPI.Services;

namespace SE.PaymentAPI.Controllers
{
    [ApiController]
    [Route("payment-intent")]
    public class PaymentIntentController : ControllerBase
    {
        private readonly IStripeService _paymentService;

        public PaymentIntentController(IStripeService paymentService)
        {
            _paymentService=paymentService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPaymentIntents([FromQuery] string customerId)
        {
            return Ok(await _paymentService.GetPaymentIntents(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentIntentDTO dto)
        {
            return Ok(await _paymentService.CreatePaymentIntent(dto.customerId));
        }
    }
}
