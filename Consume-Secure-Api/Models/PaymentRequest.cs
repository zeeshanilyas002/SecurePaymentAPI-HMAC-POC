using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consume_Secure_Api.Models
{
    public class PaymentRequest
    {
        public string TransactionId { get; set; }
        public int MerchantId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
