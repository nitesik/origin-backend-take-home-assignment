using OriginFinancialAPI.API;

namespace OriginFinancialAPI.Service;

public class RiskService : IRiskService
{
	public RiskFactor CalculateRiskFactor(User details)
	{
		RiskFactor result = new RiskFactor();

		int autoPoints = details.risk_questions.Sum();
		int disabilityPoints = details.risk_questions.Sum();
		int homePoints = details.risk_questions.Sum();
		int lifePoints = details.risk_questions.Sum();

		if (details.age < 30)
		{
			autoPoints -= 2;
			disabilityPoints -= 2;
			homePoints -= 2;
			lifePoints -= 2;
		}
		
		if (details.age > 30 && details.age < 40)
		{
			autoPoints--;
			disabilityPoints--;
			homePoints--;
			lifePoints--;
		}
		
		if (details.income > 200)
		{
			autoPoints--;
			disabilityPoints--;
			homePoints--;
			lifePoints--;
		}

		if (details.house.ownership_status == "mortgaged")
		{
			disabilityPoints++;
			homePoints++;
		}

		if (details.dependents > 0)
		{
			disabilityPoints--;
			lifePoints++;
		}

		if (details.marital_status == "married")
		{
			lifePoints++;
			disabilityPoints--;
		}

		if (details.vehicle.Length > 0)
		{
			foreach (var vehicles in details.vehicle)
			{
				if (vehicles.year >= 2018)
					autoPoints++;
			}
		}
		
		

		result.auto = autoPoints <= 0 ? "economic" : (autoPoints >= 3 ? "responsible" : "regular");
		result.disability = disabilityPoints <= 0 ? "economic" : (disabilityPoints >= 3 ? "responsible" : "regular");
		result.home = homePoints <= 0 ? "economic" : (homePoints >= 3 ? "responsible" : "regular");
		result.life = lifePoints <= 0 ? "economic" : (lifePoints >= 3 ? "responsible" : "regular");
		
		if (details.income <= 0)
		{
			result.disability = "ineligible";
			result.home = "ineligible";
			result.auto = "ineligible";
		}

		if (details.age > 60)
		{
			result.disability = "ineligible";
			result.life = "ineligible";
		}
		
		return result;
	}
}