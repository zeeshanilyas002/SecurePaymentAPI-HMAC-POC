namespace Hmac_signature_implementation.Models
{
    public class PaymentRequest
    {
        public string TransactionId { get; set; }     // Unique transaction reference
        public int MerchantId { get; set; }           // ID of the merchant initiating the transaction
        public double Amount { get; set; }            // Transaction amount in base currency
        public string Currency { get; set; }          // ISO Currency Code (e.g., "USD", "GHS")
        public string CustomerEmail { get; set; }     // Optional customer info for validation
        public DateTime RequestTime { get; set; }     // UTC timestamp for freshness
    }

}
