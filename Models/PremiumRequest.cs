namespace InsurancePremiumCalcBE.Models
{
    public class PremiumRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }
    }
}
