using System;

class Patient
{
    public int PatientId { get; }
    public string Name { get; set; }
    public int Age { get; set; }

    private string medicalHistory = "";

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }

    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }

    public string GetMedicalHistory()
    {
        return medicalHistory;
    }
}

class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public readonly string LicenseNumber;

    public static int TotalDoctors;

    static Doctor()
    {
        TotalDoctors = 0;
        Console.WriteLine("Doctor system initialized");
    }

    public Doctor(string name, string specialization, string license)
    {
        Name = name;
        Specialization = specialization;
        LicenseNumber = license;
        TotalDoctors++;
    }
}

class Appointment
{
    public void Schedule(Patient patient, Doctor doctor)
    {
        Console.WriteLine("Appointment scheduled");
        Console.WriteLine("Patient: " + patient.Name);
        Console.WriteLine("Doctor: " + doctor.Name);
    }

    public void Schedule(Patient patient, Doctor doctor, DateTime date, string mode = "Offline")
    {
        Console.WriteLine("Appointment scheduled");
        Console.WriteLine("Patient: " + patient.Name);
        Console.WriteLine("Doctor: " + doctor.Name);
        Console.WriteLine("Date: " + date.ToShortDateString());
        Console.WriteLine("Mode: " + mode);
    }
}
