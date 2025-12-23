using System;

class DiagnosisService
{
    public void Evaluate(in int age, ref string condition, out string riskLevel, int s1, int s2, int s3)
    {
        int total = s1 + s2 + s3;

        if (total > 250 || age > 60)
        {
            condition = "Serious";
            riskLevel = "High";
        }
        else
        {
            condition = "Normal";
            riskLevel = "Moderate";
        }
    }
}

class Billing
{
    public double ConsultationFee { get; set; }
    public double TestCharges { get; set; }
    public double RoomCharges { get; set; }

    public double Total()
    {
        return ConsultationFee + TestCharges + RoomCharges;
    }
}

class InsuranceService
{
    public double ApplyCoverage(double billAmount, int coveragePercent)
    {
        double discount = billAmount * coveragePercent / 100;
        return billAmount - discount;
    }
}
