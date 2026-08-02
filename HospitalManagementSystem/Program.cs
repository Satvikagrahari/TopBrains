using System;
using System.Collections.Generic;
using System.Linq;

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

public class HospitalManager
{
    private Dictionary<int, Patient> _patients;
    private Queue<Patient> _appointmentQueue;

    public HospitalManager()
    {
        _patients = new Dictionary<int, Patient>();
        _appointmentQueue = new Queue<Patient>();
    }

    // Register Patient
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (_patients.ContainsKey(id))
        {
            Console.WriteLine("Patient ID already exists.");
            return;
        }

        Patient patient = new Patient(id, name, age, condition);
        _patients.Add(id, patient);
    }

    // Schedule Appointment
    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    // Process Next Appointment
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count == 0)
            return null;

        return _appointmentQueue.Dequeue();
    }

    // Find Patients By Condition
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
                        .Where(p => p.Condition.Equals(condition,
                                StringComparison.OrdinalIgnoreCase))
                        .ToList();
    }

    // Bonus 1
    public void AddMedicalHistory(int patientId, string history)
    {
        if (_patients.ContainsKey(patientId))
        {
            _patients[patientId].MedicalHistory.Add(history);
        }
    }

    // Bonus 2
    public void DisplayPendingAppointments()
    {
        foreach (Patient p in _appointmentQueue)
        {
            Console.WriteLine($"{p.Id} {p.Name}");
        }
    }

    // Bonus 3
    public int TotalPatients()
    {
        return _patients.Count;
    }

    // Bonus 4
    public Patient GetOldestPatient()
    {
        return _patients.Values.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    // Bonus 5
    public void GroupPatientsByCondition()
    {
        var groups = _patients.Values.GroupBy(p => p.Condition);

        foreach (var group in groups)
        {
            Console.WriteLine(group.Key);

            foreach (var patient in group)
            {
                Console.WriteLine(patient.Name);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        HospitalManager manager = new HospitalManager();

        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");

        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        Patient nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name);

        List<Patient> diabeticPatients =
            manager.FindPatientsByCondition("Diabetes");

        Console.WriteLine(diabeticPatients.Count);

        // Bonus Features

        manager.AddMedicalHistory(2, "Blood Sugar Test");
        manager.AddMedicalHistory(2, "Insulin Started");

        Console.WriteLine("Pending Appointments:");
        manager.DisplayPendingAppointments();

        Console.WriteLine("Total Patients: " + manager.TotalPatients());

        Patient oldest = manager.GetOldestPatient();
        Console.WriteLine("Oldest Patient: " + oldest.Name);

        Console.WriteLine("Patients Grouped By Condition:");
        manager.GroupPatientsByCondition();
    }
}