# Premium Calculator

Dot Net Web API that calculates the premium insurance based on occupation and returns calculated monthly premium

---

## **Technologies Used**
- ASP .NET Web API version 8
- C#
  
---

## **Clarifications**
1. PremiumRequest class is the model for incoming data from client.
2. CalculatePremium method in IPremiumService will calculate the premium insurance and return backs to controller which will further sends to client.

---

## **Features**
- Implemented CustomExceptionMiddleware for un-handled exceptions if anything missed.
- Enabled CORS to prevent other domains to access the service (enabled only for http://localhost:4200).
- Enabled RateLimiting to prevent missuse by hackers (any client can send 5 request per 5 second).

---

##**Usage**
- Send a POST request with JSON body:
- Request
     {
  "name": "XXXXXX",
  "age": 30,
  "dateOfBirth": "XX/XX/XXXX",
  "occupation": "XXXXXX",
  "deathSumInsured": 100000}

  - Responce
{
  "monthlyPremium": 5400

}

---

## **Setup and Run**
1. Clone the repository:
```bash
git clone https://github.com/taraka-343/InsurancePremiumCalculator.git
