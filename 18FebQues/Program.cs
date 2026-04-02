
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    public static void Main()
    {
        // Write code to perform the following conversions and operations:

        // Convert an integer Student ID 105 into a string and display it with the message:
        // Student ID: _
        // int sid = 105;
        // string id = sid.ToString();
        // System.Console.WriteLine("Student ID: "+id); 

        // Convert the string "45" into an integer and display:
        // Available Seats: _
        // string a = "45";
        // int b = int.Parse(a);
        // System.Console.WriteLine("Available Seats: "+a);

        // Convert the string course fee "15000.50" into a decimal and display it.
        // string a = "15000.50";
        // decimal b = decimal.Parse(a);
        // System.Console.WriteLine(b);


        // Convert an int discount 15 into a double and display it as:
        // Discount Rate: 
        // _
        // int discount = 15;
        // double ddiscount = discount;
        // System.Console.WriteLine("dicount rate: "+ddiscount);


        // Convert a float attendance value 92.75f into a double and print it.
        // float a = 92.75f;
        // double b = a;
        // System.Console.WriteLine(b);


        // Convert the double duration 6.8 into an int and display the number of days.
        // double duration = 6.8;
        // int nod = (int)duration;
        // System.Console.WriteLine(nod);

        // Convert the double temperature 37.45678 into a float and display the result.
        // double temp = 37.45678;
        // float result = (float)temp;
        // System.Console.WriteLine(result);

        // Convert the decimal total amount 12345.6789m into a string formatted to 2 decimal places.
        // decimal amt = 12345.6789m;
        // string formattedamt = amt.ToString("F2");
        // System.Console.WriteLine(formattedamt);

        // Convert the character grade 'B' into its numeric (ASCII/Unicode) value.
        // char grade = 'B';
        // int unicode = grade;
        // System.Console.WriteLine(unicode); 


        // Convert the boolean value false into a string and display:
        // bool value = false;
        // string sValue = value.ToString();
        // System.Console.WriteLine(sValue);



        //         Sensor Data Normalizer
        // A weather monitoring system receives atmospheric readings from remote IoT devices. 
        // Due to unstable network conditions and inconsistent firmware versions, the readings arrive as a single string containing comma-separated values.

        // The incoming string may contain:

        // valid decimal numbers

        // whole numbers

        // extra spaces

        // empty entries

        // the word "null"

        // invalid text such as "error" or "NaN"

        // numbers with excessive decimal precision

        // Example input:
        // " 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN "

        // Requirements

        // You are asked to design a reusable C# component that processes this string and produces a clean float array.

        // Your solution must:

        // 1️⃣ Convert the input string into a float array.

        // 2️⃣ Ignore:

        // empty values

        // "null" values

        // invalid numeric entries

        // 3️⃣ Round all valid numbers to 2 decimal places.

        // 4️⃣ Return null if no valid numeric values exist after processing.

        // 5️⃣ Use multiple interfaces to separate responsibilities:

        // One interface responsible for parsing string values.

        // One interface responsible for rounding numeric values.

        // 6️⃣ Create a class that implements both interfaces and performs the full processing.

        // 7️⃣ Ensure the program safely handles unexpected or malformed input.

        // Expected output for the sample input:
        // { 24.57, 18.90, 31.00, 29.00, 18.00 }

        // Additional Conditions

        // Do NOT use exceptions for numeric conversion.

        // Follow good object-oriented design principles.

    
        string input = " 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN ";

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No valid values found.");
            return;
        }

        string[] parts = input.Split(',');
        List<float> result = new List<float>();

        foreach (string part in parts)
        {
            string value = part.Trim();

            // Ignore empty or "null"
            if (string.IsNullOrWhiteSpace(value) ||
                value.Equals("null", StringComparison.OrdinalIgnoreCase))
                continue;

            // Safe conversion (no exceptions)
            if (float.TryParse(value, NumberStyles.Float,
                               CultureInfo.InvariantCulture,
                               out float number))
            {
                if (!float.IsNaN(number))
                {
                    number = (float)Math.Round(number, 2);
                    result.Add(number);
                }
            }
        }

        if (result.Count == 0)
        {
            Console.WriteLine("No valid values found.");
        }
        else
        {
            Console.WriteLine("{ " + string.Join(", ", result) + " }");
        }
    }
}
