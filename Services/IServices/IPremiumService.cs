using InsurancePremiumCalcBE.Models;

namespace InsurancePremiumCalcBE.Services.IServices
{
    public interface IPremiumService
    {
        decimal CalculatePremium(PremiumRequest req);
    }
}
