using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(HospitalSystemInit.HospitalName);

        Console.Write("Enter Patient Id: ");
        int patientId = InputHelper.ReadAge(Console.ReadLine() ?? "0");

        Console.Write("Enter Patient Name: ");
        string patientName = Console.ReadLine() ?? "";

        Console.Write("Enter Patient Age: ");
        int patientAge = InputHelper.ReadAge(Console.ReadLine() ?? "0");

        Patient patient = new Patient(patientId, patientName, patientAge);

        Console.Write("Enter Medical History: ");
        patient.SetMedicalHistory(Console.ReadLine() ?? "");

        Console.Write("Enter Doctor Name: ");
        string doctorName = Console.ReadLine() ?? "";

        Console.Write("Enter Specialization: ");
        string specialization = Console.ReadLine() ?? "";

        Doctor doctor = new Doctor(doctorName, specialization, "LIC1001");

        Appointment appointment = new Appointment();
        appointment.Schedule(patient, doctor, DateTime.Now);

        string condition = "";
        string riskLevel;

        int ageValue = patient.Age;

        DiagnosisService diagnosis = new DiagnosisService();
        diagnosis.Evaluate(in ageValue, ref condition, out riskLevel, 80, 90, 100);

        Billing bill = new Billing
        {
            ConsultationFee = 500,
            TestCharges = 1500,
            RoomCharges = 2000
        };

        double totalBill = bill.Total();

        InsuranceService insurance = new InsuranceService();
        double finalAmount = insurance.ApplyCoverage(totalBill, 20);

        Console.WriteLine("Condition: " + condition);
        Console.WriteLine("Risk Level: " + riskLevel);
        Console.WriteLine("Final Payable Amount: " + finalAmount);
    }
}
