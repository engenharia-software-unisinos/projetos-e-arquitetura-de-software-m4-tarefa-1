using Stripe;

namespace SE.PaymentAPI.Services
{
    public interface IStripeService
    {
        public Task<StripeList<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(string id);
        public Task<Customer> AddCustomer(string name, string email, string phone, string country, string state, string city, string line1, string line2, string postalCode);
        public Task<StripeList<PaymentIntent>> GetPaymentIntents(string customerId);
        public Task<PaymentIntent> CreatePaymentIntent(string customerId);
    }
}
//var data = new
//{
//    id = Guid.NewGuid().ToString(),
//    amount = 1000,
//    billing_details = new {
//        address = new
//        {
//            city = "Porto Alegre",
//            country = "Brasil",
//            line1 = "General Lima e Silva 480",
//            line2 = "2",
//            postal_code = "90050100",
//            state = "RS"
//        },
//        email = "felipe.allmeida.dev@gmail.com",
//        name = "Felipe Rodrigues de Almeida",
//        phone = "51983468863"
//    },
//    currency = "BRL"
//};