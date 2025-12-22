using System;

sealed class Security
{
    public void authenticate()
    {
        Console.WriteLine("User Authenticated");
    }
}

abstract class InsurancePolicy
{
    public int PolicyNum { get; init; }
    public string PolicyHolder { get; set; }

    private double premium;
    public double Premium
    {
        get { return premium; }
        set
        {
            if (value > 0)
                premium = value;
        }
    }

    public virtual double premCalculate()
    {
        return Premium;
    }

    public void ShowPolicy()
    {
        Console.WriteLine("Generic Policy Information");
    }
}

class LifeInsurance : InsurancePolicy
{
    public override double premCalculate()
    {
        return Premium * 0.5;
    }

    public new void ShowPolicy()
    {
        Console.WriteLine("This is Updated Show Policy!!");
    }
}

class HealthInsurance : InsurancePolicy
{
    public sealed override double premCalculate()
    {
        return Premium * 0.1;
    }
}

class PolicyDirectory
{
    private Dictionary<int, InsurancePolicy> policies = new Dictionary<int, InsurancePolicy>();

    public InsurancePolicy this[int policyNum]
    {
        get
        {
            return policies[policyNum];
        }
        set
        {
            policies[policyNum] = value;
        }
    }

    public InsurancePolicy this[string holderName]
    {
        get
        {
            return policies.Values.FirstOrDefault(p => p.PolicyHolder == holderName);
        }
    }
}