using Microsoft.AspNetCore.Mvc;
using OriginFinancialAPI.API;
using OriginFinancialAPI.Service;

namespace OriginFinancialAPI.Controllers;

[Route("RiskFactor")]
public class RiskController : Controller
{
	private IRiskService _riskService;

	public RiskController(IRiskService riskService)
	{
		_riskService = riskService;
	}
	
	// GET
	[HttpPost]
	public IActionResult CalculateRiskFactor(User details)
	{
		var test = _riskService.CalculateRiskFactor(details);
		return Ok(test);
	}
}