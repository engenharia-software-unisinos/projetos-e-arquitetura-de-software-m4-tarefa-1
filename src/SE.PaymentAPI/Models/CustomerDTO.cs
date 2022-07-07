namespace SE.PaymentAPI.Models
{
    public record CreateCustomerDTO(string name, string email, string phone, string country, string state, string city, string line1, string line2, string postalCode);
    public record CreatePaymentIntentDTO(string customerId);
}
