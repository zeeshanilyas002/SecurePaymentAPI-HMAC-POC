// See https://aka.ms/new-console-template for more information

using Consume_Secure_Api;

var client = new PaymentClient();
await client.SendPaymentRequestAsync();

Console.WriteLine("Hello, World!");
