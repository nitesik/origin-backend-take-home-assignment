namespace OriginFinancialAPI.API;

public class User
{
	public int age { get; set; }
	public int dependents { get; set; }
	public Houses house { get; set; }
	public int income { get; set; }
	public string marital_status { get; set; } 
	public int[] risk_questions { get; set; }
	public Vehicles[] vehicle { get; set; }
}

public class Houses
{
	public string ownership_status { get; set; }
}

public class Vehicles
{
	public int year { get; set; }
}