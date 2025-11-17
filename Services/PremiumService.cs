namespace InsurancePremiumCalcBE.Services
{
    public class PremiumService
    {
        Dictionary<string, decimal> _ratingFactors = new()
        {
            { "Professional", 1.5m },
            { "White Collar", 2.25m },
            { "Light Manual", 11.50m },
            { "Heavy Manual", 31.75m }
        };
    }
}
