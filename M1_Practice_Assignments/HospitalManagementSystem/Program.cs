// Task 1: Implement Patient class with proper encapsulation
public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public List<string> MedicalHistory { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }
}


// Task 2: Implement HospitalManager class
public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        // TODO: Create patient and add to dictionary
        if (!_patients.ContainsKey(id))
        {
            Patient p = new Patient(id, name, age, condition);
            _patients.Add(id, p);
        }
        else
        {
            Console.WriteLine("Patient Already Exists");
        }
    }

    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        // TODO: Return and remove next patient from queue
        if (_appointmentQueue.Count > 0)
        {
            return _appointmentQueue.Dequeue();
        }
        return null;
    }

    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        // TODO: Use LINQ to filter patients
        return _patients.Values.Where(p => p.Condition == condition).ToList();
    }
}

class Program
{
    public static void Main(string[] args)
    {
        HospitalManager hm = new HospitalManager();
        hm.RegisterPatient(1,"Srikaran",22,"Fever");
        hm.RegisterPatient(2,"Pavan",23,"Cough");
        hm.RegisterPatient(3,"Nikhil",21,"Pain");

        hm.ScheduleAppointment(1);
        hm.ScheduleAppointment(2);

        var visited = hm.ProcessNextAppointment();
        Console.WriteLine(visited.Name);

        var findPatient = hm.FindPatientsByCondition("Fever");
        foreach(var l in findPatient)
        {
            Console.WriteLine($"{l.Name} is suffering from Fever");
        }
    }
}
