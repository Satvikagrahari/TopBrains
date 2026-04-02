// 1) Inventory Lookup - Product Stock Finder
// Create a dictionary for product code and stock count. Read a product code and print stock if present; otherwise print "Not Found".

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> inventory = new Dictionary<string, int>
//         {
//             { "P101", 25 },
//             { "P102", 0 },
//             { "P103", 14 }
//         };

//         string inputCode = Console.ReadLine();
//         // TODO: Implement lookup and print result
//         if (inventory.ContainsKey(inputCode))
//         {
//             System.Console.WriteLine(inventory[inputCode]);
//         }
//         else
//         {
//             System.Console.WriteLine("not found");
//         }
//     }
// }






// 2) Student Marks - Update Existing Key
// Store student names and marks. If a student exists, update mark; otherwise add new student.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> marks = new Dictionary<string, int>
//         {
//             { "Asha", 78 },
//             { "Bala", 82 }
//         };

//         string student = Console.ReadLine();
//         int newMark = int.Parse(Console.ReadLine());
//         // TODO: Add or update mark
//         if (marks.ContainsKey(student))
//         {
//             marks[student] = newMark;

//         }
//         else
//         {
//             marks.Add(student,newMark);
//         }
//         foreach (var item in marks)
//         {
//             System.Console.WriteLine(item.Key+ item.Value);
//         }
//     }
// }






// 3) Attendance Counter - Frequency Using Dictionary
// Given an array of employee IDs, count attendance frequency of each employee.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         int[] employeeIds = { 1001, 1002, 1001, 1003, 1002, 1001, 1001};
//         Dictionary<int, int> attendance = new Dictionary<int, int>();
//         // TODO: Build frequency map and print
//         foreach (var id in employeeIds)
//         {
//             if (attendance.ContainsKey(id))
//             {
//                 attendance[id]++;
//             }
//             else
//             {
//                 attendance[id] = 1;
//             }
//         }

//         foreach (var item in attendance)
//         {
//             System.Console.WriteLine(item.Key+" "+item.Value);
//         }
//     }
// }





// 4) Login Attempt Tracker - Increment Value
// Track failed login attempts per user. Increment attempts whenever a username is received.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string[] attempts = { "raj", "kavi", "raj", "raj", "kavi" };
//         Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
//         // TODO: Count attempts and print users with attempts >= 3

//         foreach (var user in attempts)
//         {
//             if (failedAttempts.ContainsKey(user))
//             {
//                 failedAttempts[user]++;
//             }
//             else
//             {
//                 failedAttempts[user] = 1;
//             }
//         }

//         foreach (var x in failedAttempts)
//         {
//             if (x.Value >= 3)
//             {
//                 System.Console.Write(x.Key+" ");
//             }
//         }
//     }
// }






// 5) Country Code Resolver - Safe Access
// Store country dialing codes and fetch a country code using TryGetValue.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, string> dialCodes = new Dictionary<string, string>
//         {
//             { "India", "+91" },
//             { "USA", "+1" },
//             { "Japan", "+81" }
//         };

//         string country = Console.ReadLine();
//         // TODO: Use TryGetValue to print code or "Unavailable"
//         foreach (var item in dialCodes)
//         {
//             if(dialCodes.TryGetValue(country, out string code))
//             {
//                 System.Console.WriteLine(code);
//                 return;
//             }
//         }
//         System.Console.WriteLine("Unavailable");
//     }
// }


// 6) Course Enrollment - Remove Key
// Maintain course name and enrolled count. Remove a cancelled course from dictionary.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> courses = new Dictionary<string, int>
//         {
//             { "CSharp", 30 },
//             { "SQL", 28 },
//             { "Azure", 15 }
//         };

//         string cancelledCourse = Console.ReadLine();
//         // TODO: Remove key if available and print remaining courses

//         if (courses.ContainsKey(cancelledCourse))
//         {
//             courses.Remove(cancelledCourse);

//             foreach (var item in courses)
//             {
//                 System.Console.WriteLine(item.Key + " " + item.Value);
//             }
//         }
//         else
//         {
//             System.Console.WriteLine("course not present");
//         }
//     }
// }



// 7) Price Catalog - Check Key Existence
// Given an item name, validate whether it exists in catalog before billing.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, decimal> catalog = new Dictionary<string, decimal>
//         {
//             { "Pen", 12.5m },
//             { "Book", 90m },
//             { "Bag", 450m }
//         };

//         string item = Console.ReadLine();
//         // TODO: Print item price if exists; else print "Invalid Item"

//         if (catalog.ContainsKey(item))
//         {
//             System.Console.WriteLine(catalog[item]);
//         }
//         else
//         {
//             System.Console.WriteLine("invalid item");
//         }
//     }
// }




// 8) City Temperature Board - Iterate Keys and Values
// Print each city with temperature and find the hottest city.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> temperature = new Dictionary<string, int>
//         {
//             { "Chennai", 38 },
//             { "Delhi", 41 },
//             { "Bengaluru", 29 }
//         };

//         // TODO: Iterate and find max temperature city
//         int max = 0;
//         string city = "";
//         foreach (var item in temperature)
//         {
//             if (item.Value > max)
//             {
//                 max = item.Value;
//                 city = item.Key;
//             } 
//         }
//         System.Console.WriteLine(city+" "+max);
//     }
// }

// 10) Employee Directory - Merge Dictionaries
// Merge branch1 and branch2 employee dictionaries. If duplicate key appears, prefer branch2 value.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         Dictionary<int, string> branch1 = new Dictionary<int, string>
//         {
//             { 101, "Anu" },
//             { 102, "Dev" }
//         };

//         Dictionary<int, string> branch2 = new Dictionary<int, string>
//         {
//             { 102, "Devika" },
//             { 103, "Rahul" }
//         };

//         // TODO: Merge dictionaries and print final result
//         foreach (var kvp in branch2)
//         {
//             if (branch1.ContainsKey(kvp.Key))
//             {
//                 branch1[kvp.Key] = kvp.Value;
//             }
//             else
//             {
//                 branch1.Add(kvp.Key,kvp.Value);  
//             }
                           
//         }

//         foreach (var kvp in branch1)
//         {
//             System.Console.WriteLine(kvp.Key+" "+kvp.Value);
//         }
//     }
// }




// 11) Word Dictionary - Case-Insensitive Keys
// Build a dictionary that treats "apple" and "Apple" as same key.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, string> meanings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
//         // TODO: Add words and demonstrate case-insensitive retrieval
//         meanings["apple"]="fruit";
//         meanings["Apple"]="green";
//         foreach (var kvp in meanings)
//         {
//             System.Console.WriteLine(kvp.Key+":"+kvp.Value);
//         }
//     }
// }




// 12) Ticket Priority Queue Snapshot - Group Counts
// From ticket priorities array (High/Medium/Low), produce a dictionary count per priority.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         string[] priorities = { "High", "Low", "Medium", "High", "High", "Low" };
//         Dictionary<string, int> priorityCount = new Dictionary<string, int>();
//         // TODO: Count each priority bucket
//         foreach (var item in priorities)
//         {
//             if (priorityCount.ContainsKey(item))
//             {
//                priorityCount[item]++; 
//             } 
//             else
//             {
//                 priorityCount[item] = 1;
//             }
//         }

//         foreach (var kvp in priorityCount)
//         {
//             System.Console.WriteLine(kvp.Key+":"+kvp.Value);
//         }

//     }
// }

