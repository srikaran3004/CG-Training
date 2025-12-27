using System;

class PatientBill
{
    public string? BillId { get; set; }
    public string? PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }

    public decimal GrossAmount { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal FinalPayable { get; private set; }

    public static PatientBill LastBill;
    public static bool HasLastBill = false;

    public void CalculateBill()
    {
        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

        if (HasInsurance)
            DiscountAmount = GrossAmount * 0.10m;
        else
            DiscountAmount = 0;

        FinalPayable = GrossAmount - DiscountAmount;
    }

    public static void DisplayLastBill()
    {
        if (!HasLastBill || LastBill == null)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("----------- Last Bill Details -----------");
        Console.WriteLine($"BillId: {LastBill.BillId}");
        Console.WriteLine($"Patient: {LastBill.PatientName}");
        Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
        Console.WriteLine("--------------------------------");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}
