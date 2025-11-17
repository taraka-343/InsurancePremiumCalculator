using InsurancePremiumCalcBE.Models;
using InsurancePremiumCalcBE.Services;
using InsurancePremiumCalcBE.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InsurancePremiumCalcBE.Controller
{
    [EnableRateLimiting("FixedWindowPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumService _premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }
        [HttpPost("calculate")]
        public IActionResult CalculatePremium([FromBody] PremiumRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var premium = _premiumService.CalculatePremium(request);

            return Ok(new { monthlyPremium = premium });
        }
    }
}
