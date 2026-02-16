namespace HealthSyncAdvancedBilling
{
    public abstract class Consultant
    {
        public string Id{get;set;}="";
        public abstract double CalculateGrossPayout();
    }
}