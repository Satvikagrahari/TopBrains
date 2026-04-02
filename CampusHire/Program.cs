using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        ApplicantService service = new ApplicantService();

        while (true)
        {
            Console.WriteLine("\n1. Add Applicant");
            Console.WriteLine("2. Display All Applicants");
            Console.WriteLine("3. Search Applicant by ID");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Applicant a = ReadApplicant();
                        service.AddApplicant(a);
                        Console.WriteLine("Applicant added successfully");
                        break;

                    case 2:
                        service.DisplayAll();
                        break;

                    case 3:
                        Console.Write("Enter Applicant ID: ");
                        Console.WriteLine(service.SearchById(Console.ReadLine()));
                        break;

                    case 4:
                        Console.Write("Enter Applicant ID to update: ");
                        string id = Console.ReadLine();
                        Applicant updated = ReadApplicant();
                        service.UpdateApplicant(id, updated);
                        Console.WriteLine("Applicant updated successfully");
                        break;

                    case 5:
                        Console.Write("Enter Applicant ID to delete: ");
                        service.DeleteApplicant(Console.ReadLine());
                        Console.WriteLine("Applicant deleted successfully");
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static Applicant ReadApplicant()
    {
        Console.Write("Applicant ID (Example CH123456): ");
        string id = Console.ReadLine();

        Console.Write("Applicant Name: ");
        string name = Console.ReadLine();

        Console.Write("Current Location (Mumbai/Pune/Chennai): ");
        string current = Console.ReadLine();

        Console.Write("Preferred Location (Mumbai/Pune/Chennai/Delhi/Kolkata/Bangalore): ");
        string pref = Console.ReadLine();

        Console.Write("Core Competency (.NET/JAVA/ORACLE/Testing): ");
        string core = Console.ReadLine();

        Console.Write("Passing Year: ");
        int year = int.Parse(Console.ReadLine());

        return new Applicant
        {
            ApplicantId = id,
            ApplicantName = name,
            CurrentLocation = current,
            PreferredLocation = pref,
            CoreCompetency = core,
            PassingYear = year
        };
    }
}

class Applicant
{
    public string ApplicantId { get; set; }
    public string ApplicantName { get; set; }
    public string CurrentLocation { get; set; }
    public string PreferredLocation { get; set; }
    public string CoreCompetency { get; set; }
    public int PassingYear { get; set; }

    public override string ToString()
    {
        return $"{{ Id: {ApplicantId}, Name: {ApplicantName}, CurrentLocation: {CurrentLocation}, PreferredLocation: {PreferredLocation}, Core: {CoreCompetency}, PassingYear: {PassingYear} }}";
    }
}

class ApplicantService
{
    private List<Applicant> applicants = new List<Applicant>();
    private const string filePath = "applicants.json";

    public ApplicantService()
    {
        LoadFromFile();
    }

    public void AddApplicant(Applicant applicant)
    {
        ValidateApplicant(applicant);

        if (applicants.Any(a => a.ApplicantId == applicant.ApplicantId))
            throw new Exception("Applicant ID already exists");

        applicants.Add(applicant);
        SaveToFile();
    }

    public void DisplayAll()
    {
        if (!applicants.Any())
        {
            Console.WriteLine("No records found");
            return;
        }

        applicants.ForEach(a => Console.WriteLine(a));
    }

    public Applicant SearchById(string id)
    {
        return applicants.FirstOrDefault(a => a.ApplicantId == id)
               ?? throw new Exception("Applicant not found");
    }

    public void UpdateApplicant(string id, Applicant updated)
    {
        var existing = SearchById(id);
        ValidateApplicant(updated);

        existing.ApplicantName = updated.ApplicantName;
        existing.CurrentLocation = updated.CurrentLocation;
        existing.PreferredLocation = updated.PreferredLocation;
        existing.CoreCompetency = updated.CoreCompetency;
        existing.PassingYear = updated.PassingYear;

        SaveToFile();
    }

    public void DeleteApplicant(string id)
    {
        var applicant = SearchById(id);
        applicants.Remove(applicant);
        SaveToFile();
    }

    private void ValidateApplicant(Applicant a)
    {
        if (string.IsNullOrWhiteSpace(a.ApplicantId) ||
            string.IsNullOrWhiteSpace(a.ApplicantName) ||
            string.IsNullOrWhiteSpace(a.CurrentLocation) ||
            string.IsNullOrWhiteSpace(a.PreferredLocation) ||
            string.IsNullOrWhiteSpace(a.CoreCompetency))
            throw new Exception("All fields are mandatory");

        if (a.ApplicantId.Length != 8 || !a.ApplicantId.StartsWith("CH"))
            throw new Exception("Applicant ID must start with CH and be exactly 8 characters");

        if (a.ApplicantName.Length < 4 || a.ApplicantName.Length > 15)
            throw new Exception("Name must be between 4 and 15 characters");

        if (a.PassingYear > DateTime.Now.Year)
            throw new Exception("Passing year cannot be greater than current year");
    }

    private void SaveToFile()
    {
        string json = JsonSerializer.Serialize(applicants);
        File.WriteAllText(filePath, json);
    }

    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            applicants = JsonSerializer.Deserialize<List<Applicant>>(json)
                         ?? new List<Applicant>();
        }
    }
}
