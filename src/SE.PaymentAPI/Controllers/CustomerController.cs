using Microsoft.AspNetCore.Mvc;
using SE.PaymentAPI.Models;
using SE.PaymentAPI.Services;

namespace SE.PaymentAPI.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IStripeService _paymentService;

        public CustomerController(IStripeService paymentService)
        {
            _paymentService=paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _paymentService.GetCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _paymentService.GetCustomer(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerDTO dto)
        {
            return Ok(await _paymentService.AddCustomer(dto.name, dto.email, dto.phone, dto.country, dto.state, dto.city, dto.line1, dto.line2, dto.postalCode));
        }
    }
}
