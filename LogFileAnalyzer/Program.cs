using System;
using System.Collections.Generic;
using System.Globalization;

class Log
{
    public string Level { get; set; }
    public string User { get; set; }
    public string Action { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static void Main()
    {
        string input = "INFO:User1:Login:2026-02-18," +
                       "ERROR:User2:PaymentFailed:18-02-2026," +
                       "WARN:User3:LowBalance:2026/02/18," +
                       "INVALID ENTRY," +
                       "INFO:User4:Logout:2026-02-19";

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No logs found.");
            return;
        }

        List<Log> logs = new List<Log>();

        // Step 1: Split entries
        string[] entries = input.Split(',');

        foreach (string entry in entries)
        {
            string trimmedEntry = entry.Trim();

            if (string.IsNullOrWhiteSpace(trimmedEntry))
                continue;

            // Step 2: Split fields
            string[] parts = trimmedEntry.Split(':');

            if (parts.Length != 4)
                continue;

            string level = parts[0].Trim();
            string user = parts[1].Trim();
            string action = parts[2].Trim();
            string dateString = parts[3].Trim();

            // Step 3: Validate LogLevel
            if (!IsValidLevel(level))
                continue;

            // Step 4: Validate Date
            DateTime parsedDate;
            if (!DateTime.TryParse(dateString, out parsedDate))
                continue;

            // Step 5: Create object
            Log log = new Log();
            log.Level = level;
            log.User = user;
            log.Action = action;
            log.Date = parsedDate;

            logs.Add(log);
        }

        // Step 6: Output Results
        DisplayResults(logs);
    }

    static bool IsValidLevel(string level)
    {
        return level == "INFO" ||
               level == "ERROR" ||
               level == "WARN";
    }

    static void DisplayResults(List<Log> logs)
    {
        Console.WriteLine("Total Valid Logs: " + logs.Count);

        int infoCount = 0;
        int errorCount = 0;
        int warnCount = 0;

        foreach (Log log in logs)
        {
            if (log.Level == "INFO") infoCount++;
            else if (log.Level == "ERROR") errorCount++;
            else if (log.Level == "WARN") warnCount++;
        }

        Console.WriteLine("INFO: " + infoCount);
        Console.WriteLine("ERROR: " + errorCount);
        Console.WriteLine("WARN: " + warnCount);

        // Manual sort (Descending by Date)
        for (int i = 0; i < logs.Count - 1; i++)
        {
            for (int j = i + 1; j < logs.Count; j++)
            {
                if (logs[i].Date < logs[j].Date)
                {
                    Log temp = logs[i];
                    logs[i] = logs[j];
                    logs[j] = temp;
                }
            }
        }

        Console.WriteLine("\nLogs (Sorted by Date Desc):");

        foreach (Log log in logs)
        {
            Console.WriteLine($"{log.Level} {log.User} {log.Action} {log.Date}");
        }
    }
}
