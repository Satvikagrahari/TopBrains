// Question
// 6
// Dictionary
// Description
// Dictionary Lookup
// Given a dictionary of (EmployeeId, Salary) and a list of EmployeeIds, return the total salary.

// Input
// Ids: {1, 4, 5}
// Dictionary: {1:20000, 4:40000, 5:15000}

// Output
// 75000

using System;


class Program
{

    public static double SalarySum(int id, Dictionary<int, double> emp)
    {
        double sum = 0;
        if (emp.ContainsKey(id))
        {
            return emp[id];
        }
        return 0;
    }
    public static void Main()
    {
        Dictionary<int, double> employee = new Dictionary<int, double>();
        List<int> empidList = new List<int>();
        System.Console.Write("Dictionary: ");
        string dictvalue = Console.ReadLine();
        string[] dictvaluepairs = dictvalue.Split(",");
        foreach (var item in dictvaluepairs)
        {
            string[] kv = item.Split(":");
            int key = int.Parse(kv[0].Trim());
            double value = double.Parse(kv[1].Trim());
            employee.Add(key, value);
        }
        System.Console.Write("Ids: ");
        string id = Console.ReadLine();
        string[] idarr = id.Split(",");
        foreach (var item in idarr)
        {
            empidList.Add(int.Parse(item.Trim()));
        }
        double sum = 0;
        foreach (var item in empidList)
        {
            sum += Program.SalarySum(item, employee);
        }
        System.Console.WriteLine(sum);

    }
}