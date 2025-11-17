using InsurancePremiumCalcBE.Models;
using InsurancePremiumCalcBE.Services.IServices;

namespace InsurancePremiumCalcBE.Services
{
    public class PremiumService : IPremiumService
    {
        Dictionary<string, decimal> _ratingFactors = new()
        {
            { "Professional", 1.5m },
            { "White Collar", 2.25m },
            { "Light Manual", 11.50m },
            { "Heavy Manual", 31.75m }
        };
        public decimal CalculatePremium(PremiumRequest req)
        {
            decimal factor = _ratingFactors[req.Occupation];

            return (req.DeathSumInsured * factor * req.Age) / 1000 * 12;
        }
    }
}
