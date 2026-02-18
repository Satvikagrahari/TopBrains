using System;
using System.Text;

class Program
{
    public static void Main()
    {

        // CHAR-Based Questions
        // Most frequent character.
        // string s = "ssfffkkkk".ToLower();
        // int max = 0;  
        // char maxChar = s[0] ;
        
        // for (int i = 0; i < s.Length; i++)
        // {
        //     int count = 1;
        //     for (int j = i+1; j < s.Length; j++)
        //     {
        //         if(s[j] == s[i]) count++;
        //     }
        //     if (max < count)
        //     {
        //         max = count;
        //         maxChar = s[i];
        //     }
            
        // }
        // System.Console.WriteLine(maxChar+" "+max);

         // string toConvert = "42";
        // int converted = int.Parse(toConvert);
        // System.Console.WriteLine(converted.GetType());

        // string toConvert = "12.34";
        // double converted = double.Parse(toConvert);
        // System.Console.WriteLine("{0:F2}",converted);

        // var toConvert = "1 2 3 4";
        // var converted = toConvert.Split(' ').Select(int.Parse);
        // System.Console.WriteLine(converted);

        // string a = "15 7abc32 dc";
        // int[] arr = a.Where(Char.IsDigit).Select(x => x - '0').ToArray();
        // System.Console.WriteLine(string.Join(",",arr));

        // Remove everything except letters and spaces.
        // string a = "12fv22 fdv21";
        // var b = new string(a.Where(c => Char.IsLetter(c) || c==' ').ToArray());
        // System.Console.WriteLine(b); 


        // Validate username: alphanumeric only, length ≥ 8.
        // string username = "abcd1234";
        // System.Console.WriteLine(ValidateUsername(username));


        // Detect if more than 60% characters are uppercase.
        // string tocheck = "AAAAAAasdf";
        // int count = 0;
        // foreach (var x in tocheck)
        // {
        //     if (Char.IsUpper(x))
        //     {
        //         count++;
        //     }
        // }
        // double percent60 = tocheck.Length*0.6;

        // if (count>=percent60)
        // {
        //     System.Console.WriteLine("valid");
        // }
        // else
        // {
        //     System.Console.WriteLine("not valid");
        // }


        // Reverse a very large string using StringBuilder.
        // string toreverse = "abcdef";
        // StringBuilder sb = new StringBuilder(toreverse);
        // int left = 0;
        // int right = sb.Length-1;
        // while (left<right)
        // {
        //     var temp = sb[left];
        //     sb[left] = sb[right];
        //     sb[right] = temp;
        //     left++; right--;            
        // }
        // System.Console.WriteLine(sb);   


        // Run-length encoding (e.g., "aaabbcccc" → "a3b2c4").
    //     string toencode = "aaaAABBSSss".ToLower();
        
    //     int n = toencode.Length;
    //     if (n == 0)
    //     {
    //         System.Console.WriteLine("Empty string");
    //         return;
    //     }
        
    //     string encoded = "";
    //     char temp = toencode[0];
    //     int count = 0;
        
    //     for (int i = 0; i < n; i++)
    //     {
    //         if (temp == toencode[i])
    //         {
    //             count++;
    //         }
    //         else
    //         {
    //             encoded += temp;
    //             encoded += count;
    //             temp = toencode[i];
    //             count = 1;
    //         }
    //     }
    //     encoded += toencode[n - 1];
    //     encoded += count;
    //     System.Console.WriteLine(encoded);

    // Insert '*' between every two characters.
    // string input = "ascdddcj";
    // StringBuilder sb = new StringBuilder();
    
    // for(int i=0; i<input.Length; i++)
    //     {
    //         sb.Append(input[i]);
    //         if (i < input.Length-1)
    //         {
    //             sb.Append("*");
    //         }
    //     }
    
    // System.Console.WriteLine(sb);

    

        
    }
    public static string ValidateUsername(string username)
    {
        if (username.Length < 8) return "not valid";
        else
        {
            foreach (var x in username)
            {
                if (!Char.IsLetterOrDigit(x))
                {
                    return "not valid";
                }
            }
        }
        return "valid";
    }

}