using System;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateBill();
                    break;
                case 2:
                    PatientBill.DisplayLastBill();
                    break;
                case 3:
                    PatientBill.ClearLastBill();
                    break;
                case 4:
                    running = false;
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;
                default:
                    Console.WriteLine("Invalid menu option. Please try again.");
                    break;
            }
        }
    }

    static void CreateBill()
    {
        PatientBill bill = new PatientBill();

        Console.Write("Enter Bill Id: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        bill.HasInsurance = Console.ReadLine().ToUpper() == "Y";

        Console.Write("Enter Consultation Fee: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal consultFee) || consultFee <= 0)
        {
            Console.WriteLine("Consultation Fee must be greater than 0.");
            return;
        }
        bill.ConsultationFee = consultFee;

        Console.Write("Enter Lab Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal labFee) || labFee < 0)
        {
            Console.WriteLine("Lab Charges must be >= 0.");
            return;
        }
        bill.LabCharges = labFee;

        Console.Write("Enter Medicine Charges: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal medFee) || medFee < 0)
        {
            Console.WriteLine("Medicine Charges must be >= 0.");
            return;
        }
        bill.MedicineCharges = medFee;

        bill.CalculateBill();

        PatientBill.LastBill = bill;
        PatientBill.HasLastBill = true;

        Console.WriteLine("Bill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
        Console.WriteLine("------------------------------------------------------------");
    }
}
