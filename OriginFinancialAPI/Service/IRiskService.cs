using OriginFinancialAPI.API;

namespace OriginFinancialAPI.Service;

public interface IRiskService
{
	public RiskFactor CalculateRiskFactor(User details);
}