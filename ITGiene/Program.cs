// using System;
// using System.Net.Mail;
// using System.Text;

// class Program
// {
//     public static void Main()
//     {

//         // CHAR-Based Questions
//         // Most frequent character.
//         // string s = "ssfffkkkk".ToLower();
//         // int max = 0;  
//         // char maxChar = s[0] ;

//         // for (int i = 0; i < s.Length; i++)
//         // {
//         //     int count = 1;
//         //     for (int j = i+1; j < s.Length; j++)
//         //     {
//         //         if(s[j] == s[i]) count++;
//         //     }
//         //     if (max < count)
//         //     {
//         //         max = count;
//         //         maxChar = s[i];
//         //     }

//         // }
//         // System.Console.WriteLine(maxChar+" "+max);

//         // string toConvert = "42";
//         // int converted = int.Parse(toConvert);
//         // System.Console.WriteLine(converted.GetType());

//         // string toConvert = "12.34";
//         // double converted = double.Parse(toConvert);
//         // System.Console.WriteLine("{0:F2}",converted);

//         // var toConvert = "1 2 3 4";
//         // var converted = toConvert.Split(' ').Select(int.Parse);
//         // System.Console.WriteLine(converted);

//         // string a = "15 7abc32 dc";
//         // int[] arr = a.Where(Char.IsDigit).Select(x => x - '0').ToArray();
//         // System.Console.WriteLine(string.Join(",",arr));

//         // Remove everything except letters and spaces.
//         // string a = "12fv22 fdv21";
//         // var b = new string(a.Where(c => Char.IsLetter(c) || c==' ').ToArray());
//         // System.Console.WriteLine(b); 


//         // Validate username: alphanumeric only, length ≥ 8.
//         // string username = "abcd1234";
//         // System.Console.WriteLine(ValidateUsername(username));


//         // Detect if more than 60% characters are uppercase.
//         // string tocheck = "AAAAAAasdf";
//         // int count = 0;
//         // foreach (var x in tocheck)
//         // {
//         //     if (Char.IsUpper(x))
//         //     {
//         //         count++;
//         //     }
//         // }
//         // double percent60 = tocheck.Length*0.6;

//         // if (count>=percent60)
//         // {
//         //     System.Console.WriteLine("valid");
//         // }
//         // else
//         // {
//         //     System.Console.WriteLine("not valid");
//         // }


//         // Reverse a very large string using StringBuilder.
//         // string toreverse = "abcdef";
//         // StringBuilder sb = new StringBuilder(toreverse);
//         // int left = 0;
//         // int right = sb.Length-1;
//         // while (left<right)
//         // {
//         //     var temp = sb[left];
//         //     sb[left] = sb[right];
//         //     sb[right] = temp;
//         //     left++; right--;            
//         // }
//         // System.Console.WriteLine(sb);   


//         // Run-length encoding (e.g., "aaabbcccc" → "a3b2c4").
//         //     string toencode = "aaaAABBSSss".ToLower();

//         //     int n = toencode.Length;
//         //     if (n == 0)
//         //     {
//         //         System.Console.WriteLine("Empty string");
//         //         return;
//         //     }

//         //     string encoded = "";
//         //     char temp = toencode[0];
//         //     int count = 0;

//         //     for (int i = 0; i < n; i++)
//         //     {
//         //         if (temp == toencode[i])
//         //         {
//         //             count++;
//         //         }
//         //         else
//         //         {
//         //             encoded += temp;
//         //             encoded += count;
//         //             temp = toencode[i];
//         //             count = 1;
//         //         }
//         //     }
//         //     encoded += toencode[n - 1];
//         //     encoded += count;
//         //     System.Console.WriteLine(encoded);

//         // Insert '*' between every two characters.
//         // string input = "ascdddcj";
//         // StringBuilder sb = new StringBuilder();

//         // for(int i=0; i<input.Length; i++)
//         //     {
//         //         sb.Append(input[i]);
//         //         if (i < input.Length-1)
//         //         {
//         //             sb.Append("*");
//         //         }
//         //     }

//         // System.Console.WriteLine(sb);

//         // Anagram Checker
//         // string a = "silent";
//         // string b = "lvggvn";
//         // var result = Program.AnagramChecker(a, b);
//         // System.Console.WriteLine(result);

//         // Remove duplicate characters while preserving order.
//         // string input = "achhhcbr";
//         // HashSet<char> Unique = new HashSet<char>();
//         // StringBuilder sb = new StringBuilder();
//         // foreach (var item in input)
//         // {
//         //     if (Unique.Add(item))
//         //     {
//         //         sb.Append(item);
//         //     }
//         // }
//         // string ans = sb.ToString();
//         // System.Console.WriteLine(ans);


//         // Find all palindromic substrings.
//         // string input = "tit,tom,pap,nsjn   ";
//         // string[] inputArr = input.Trim().Split(",");
//         // StringBuilder Result = new StringBuilder();
//         // foreach (var item in inputArr)
//         // {
//         //     string word = new string(item.Reverse().ToArray());
//         //     if(item == word)
//         //     {
//         //         Result.Append(item+",");
                
//         //     }
//         // }
//         // System.Console.WriteLine(Result.ToString().TrimEnd(","));


//         // Case-insensitive replace without regex.
//         // string input = "Hello World, HELLO everyone";
//         // string Target = "hello";
//         // string replacement = "Hi";
//         // string[] inputArr = input.Split(" ");
//         // StringBuilder sb = new StringBuilder();
//         // foreach(var word in inputArr)
//         // {
//         //     if(String.Equals(word,Target, StringComparison.OrdinalIgnoreCase))
//         //     {
//         //         sb.Append(replacement);
//         //     }
//         //     else
//         //     {
//         //         sb.Append(word);
//         //     }
//         // }
//         // System.Console.WriteLine(sb.ToString());



//         // Email masking ("john.doe@gmail.com" → "j***@gmail.com").
//         // string input = "john.doe@gmail.com";
//         // StringBuilder sb = new StringBuilder(); 
//         // sb.Append(input[0]);
//         // int count = 0;
//         // for (int i = 1; i < input.Length; i++)
//         // {
//         //     if(input[i] != '@' && count==0)
//         //     {
//         //         sb.Append("*");
//         //     }
//         //     if(input[i]=='@')
//         //     {
//         //         sb.Append(input[i]);
//         //         count++;
//         //     }
//         //     if(input[i] != '@' && count>0)
//         //     {
//         //         sb.Append(input[i]);
//         //     }
//         // }
//         // System.Console.WriteLine(sb.ToString());

//         // Alternate solution
//         // string input = "john.doe@gmail.com";
//         // int indexof = input.IndexOf('@');
//         // string ans = input[0]+"***"+input.Substring(indexof);
//         // System.Console.WriteLine(ans);


//         System.Console.WriteLine(DateTime.Now);







//     }
//     public static bool AnagramChecker(string a, string b)
//     {
//         if (a.Length != b.Length) return false;
//         var sA = new string(a.OrderBy(x => x).ToArray());
//         var sB = new string(b.OrderBy(x => x).ToArray());
//         if (sA == sB)
//         {
//             return true;
//         }
//         return false;
//     }


//     public static string ValidateUsername(string username)
//     {
//         if (username.Length < 8) return "not valid";
//         else
//         {
//             foreach (var x in username)
//             {
//                 if (!Char.IsLetterOrDigit(x))
//                 {
//                     return "not valid";
//                 }
//             }
//         }
//         return "valid";
//     }

// }

