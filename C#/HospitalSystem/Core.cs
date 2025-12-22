using System;
class Patient
{
    public int PatId { get; }
    public string Name { get; set; }
    public int Age { get; set; }
    private string medicalHistory;
    public Patient()
    {
        PatId = 0;
        Name = "";
        Age = 0;
    }
    public Patient(int id, string name, int age)
    {
        PatId = id;
        Name = name;
        Age = age;
    }
    public setHistory(string history)
    {
        return medicalhistory;
    }
}

class Doctor
{
    public string Name { get; set; }
    public string Spec { get; set; }
    public readonly string LicenceNo;
    public static int DocCnt;
    static Doctor()
    {
        
    }
}