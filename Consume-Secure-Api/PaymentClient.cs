using Consume_Secure_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consume_Secure_Api
{
    public class PaymentClient
    {
        private static readonly string apiUrl = "https://localhost:7104/api/payment/SecurePaymentRequest";
        private static readonly string secretKey = "tvgufjmdhfgrfcvjghids"; // Same as on server

        public async Task SendPaymentRequestAsync()
        {
            var request = new PaymentRequest
            {
                TransactionId = "TXN123456",
                MerchantId = 101,
                Amount = 200.50,
                Currency = "GHS",
                CustomerEmail = "customer@example.com",
                RequestTime = DateTime.UtcNow
            };

            var json = JsonConvert.SerializeObject(request);
            var signature = ComputeHmac(json, secretKey);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.Add("X-HMAC-SIGNATURE", signature);

                var response = await client.PostAsync(apiUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response: {responseContent}");
            }
        }

        private string ComputeHmac(string data, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
