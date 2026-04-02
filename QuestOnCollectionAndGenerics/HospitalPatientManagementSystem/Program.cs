// 📊 Challenge 1: Hospital Patient Management System
// Scenario
// You're building a patient management system for a hospital. The hospital needs to track patients, their appointments, and medical records efficiently using appropriate collections.
// Requirements
// 1.	Create a Patient class with: Id (int), Name (string), Age (int), Condition (string)
// 2.	Use a Dictionary<int, Patient> to store patients by ID
// 3.	Use a Queue<Patient> for the appointment waiting list
// 4.	Use a List<string> for each patient's medical history

// Task 1: Implement Patient class with proper encapsulation

// public class DupliactePatient : Exception
// {
//     public DuplicatePatient (string message) : base(message){ }
    
// }
public class Patient
{
    // TODO: Add properties with get/set accessors
    // TODO: Add constructor
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
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
        if (_patients.ContainsKey(id))
        {
            // throw new DupliactePatient("Patient with this id already exsists");
            System.Console.WriteLine("Patient with this id already exsists");
            return;
        }
        Patient patient = new Patient(id, name, age, condition);
        _patients.Add(id, patient);

    }

    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue

        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
            System.Console.WriteLine("Appointment Scheduled");
        }
        else
        {
            System.Console.WriteLine("Patient not found");
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
        
        var patient = _patients.Values.Where(x => x.Condition == condition).ToList();
       
        return patient;
    }
}

public class Program
{
    public static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name); // Should output: John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count); // Should output: 1
    }
}

