Here's a clean and professional `README.md` file content for your GitHub repository that includes both the **API** and the **client console app**:

---

```markdown
# 🔐 HMAC Signature Implementation – Secure API Communication (.NET Core)

This repository contains a **Proof of Concept (POC)** implementation of securing API requests using **HMAC (Hash-based Message Authentication Code)** in .NET Core. It includes:

- `Hmac-signature-implementation`: An ASP.NET Core Web API that validates signed requests using HMAC.
- `Consume-Secure-Api`: A .NET Core console application that generates the HMAC signature and securely calls the API.

---

## 📁 Projects Overview

### 📦 Hmac-signature-implementation (API)

A secured API endpoint that validates the integrity of incoming requests using HMAC signatures.

**Key Features:**
- Rejects tampered payloads.
- Rejects invalid or negative amounts.
- Responds with `401 Unauthorized` if the signature is invalid.

**Endpoint:**

```

POST /api/payment/SecurePaymentRequest
Headers:
Content-Type: application/json
X-HMAC-SIGNATURE: <computed HMAC>

````

**Signature Verification Logic:**

```csharp
private string ComputeHMAC(string data, string key)
{
    using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
    {
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToBase64String(hashBytes);
    }
}
````

---

### 💻 Consume-Secure-Api (Console Client)

A client that creates a JSON payload, signs it with a shared secret key, and sends it to the secure API.

**Key Actions:**

* Builds a sample payment request.
* Computes the HMAC signature.
* Sends the request with the signature in a custom header.
* Prints response status and message.

**Client Call Example:**

```csharp
var client = new PaymentClient();
await client.SendPaymentRequestAsync();
```

**Output:**

```
Status Code: 200 OK
Response: Payment accepted securely.
```

---

## 🔐 Shared Secret

Both API and client share the same secret key:

```csharp
private const string secretKey = "tvgufjmdhfgrfcvjghids";
```

> ⚠️ **Important:** In real-world scenarios, never hardcode the secret. Use a secure vault like Azure Key Vault, AWS Secrets Manager, or environment variables.

---

## 🛠️ How to Run

### Prerequisites

* .NET 6 or later
* Visual Studio / VS Code / CLI
* Enable HTTPS (or trust localhost dev certificate)

### Steps

1. **Run the API**

   * Project: `Hmac-signature-implementation`
   * Ensure it's running at `https://localhost:7104`

2. **Run the Client**

   * Project: `Consume-Secure-Api`
   * It will automatically sign the payload and call the secure API.

---

## ✅ Use Cases

* Prevent request tampering
* Validate sensitive parameters (like amount, IDs, tokens)
* Basic request integrity for internal microservices

---

## 📌 Security Note

This implementation focuses on request integrity, **not authentication**. For production systems, combine HMAC with:

* HTTPS (Always)
* Timestamp & nonce (for replay protection)
* API keys or tokens (for authentication)
* Secret storage best practices

---

## 📄 License

This project is for educational/demo purposes. Adapt and secure it before using in production.

---

```

Let me know if you'd like this in a downloadable `.md` file or want a `.gitignore` and `LICENSE` template added too.
```
