using Hmac_signature_implementation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Hmac_signature_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private const string SecretKey = "tvgufjmdhfgrfcvjghids"; // Store securely, e.g., in Azure Key Vault or AWS Secrets Manager

        [HttpPost("SecurePaymentRequest")]
        public IActionResult SecurePaymentRequest([FromBody] PaymentRequest request)
        {
            string incomingSignature = Request.Headers["X-HMAC-SIGNATURE"];
            string payload = JsonConvert.SerializeObject(request);

            string calculatedSignature = ComputeHMAC(payload, SecretKey);

            if (!incomingSignature.Equals(calculatedSignature, StringComparison.OrdinalIgnoreCase))
            {
                return Unauthorized("Request integrity compromised.");
            }

            if (request.Amount <= 0)
            {
                return BadRequest("Invalid amount.");
            }

            // Business logic proceeds here
            return Ok("Payment accepted securely.");
        }

        private string ComputeHMAC(string data, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }

}
