using Stripe;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SE.PaymentAPI.Services
{
    public class StripeService : IStripeService
    {
        public StripeService(IConfiguration configuration)
        {
            Stripe.StripeConfiguration.ApiKey = configuration["Stripe:Key"];
        }

        public async Task<StripeList<Customer>> GetCustomers()
        {
            var options = new CustomerListOptions()
            {
                Limit = 10
            };

            return await new CustomerService().ListAsync(options);
        }

        public async Task<Customer> GetCustomer(string id)
        {
            return await new CustomerService().GetAsync(id);
        }

        public async Task<Customer> AddCustomer(string name, string email, string phone, string country, string state, string city, string line1, string line2, string postalCode)
        {
            var options = new CustomerCreateOptions
            {
                Address = new AddressOptions
                {
                    Line1 = line1,
                    Line2 = line2,
                    City = city,
                    State = state,
                    Country = country,
                    PostalCode = postalCode
                },
                Email = email,
                Phone = phone,
                Name = name,
                
            };

            var service = new CustomerService();
            return await service.CreateAsync(options);
        }

        public async Task<Card> AddPaymentMethod(string customerId, string number, long expirationMonth, long expirationYear)
        {
            var options = new CardCreateOptions
            {
                Source = new CardCreateNestedOptions
                {
                    Number = number,
                    ExpMonth = expirationMonth,
                    ExpYear = expirationYear
                }
            };

            var service = new CardService();
            return await service.CreateAsync(customerId, options);
        }

        public async Task<StripeList<PaymentMethod>> GetCustomerPaymentMethods(string customerId)
        {
            var options = new PaymentMethodListOptions
            {
                Customer = customerId,
                Type = "card"
            };
            return await new PaymentMethodService().ListAsync(options);
        }

        public async Task<StripeList<PaymentIntent>> GetPaymentIntents(string customerId)
        {
            var options = new PaymentIntentListOptions()
            {
                Customer = customerId,
                Limit = 10
            };

            return await new PaymentIntentService().ListAsync(options);
        }

        public async Task<PaymentIntent> CreatePaymentIntent(string customerId)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = 2000000,
                Currency = "brl",
                Customer = customerId,
                PaymentMethodTypes = new List<string> { "boleto" }
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }
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