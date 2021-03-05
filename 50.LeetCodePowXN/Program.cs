using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.CodeDom;

namespace _50.LeetCodePowXN
{
    class Program
    {

        static void Main(string[] args)
        {
          
            string checkanswer = "";
            //double basenumber;
            //int power;
            //do
            //{
            //    Console.WriteLine("Enter N to exit or string to process");
            //    checkanswer = Console.ReadLine();
            //    if (checkanswer != "N")
            //    {
            //        Console.WriteLine("input base");
            //        basenumber = double.Parse(Console.ReadLine());
            //        Console.WriteLine("input power");
            //        power = int.Parse(Console.ReadLine());
            //        Console.WriteLine(Solution.myPow(basenumber, power));
            //    }
            //} while (checkanswer != "N");
            //Console.WriteLine($"result : {Solution.Search(new int[]{(-1), 0, 3, 5, 9, 12}, 9)}");
            string str = "This is a random sequence";
            string result = str.Substring(0, str.LastIndexOf("is")) + str.Substring(str.LastIndexOf("random"));
            Console.WriteLine(result);
            Console.ReadKey();
        }


    }

    public static class Solution
    {
        public static List<string> testIfWebsite(string url)
        {
            const string pattern = @"https://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();
            MatchCollection myMatches = Regex.Matches(url, pattern);
            result = (List<string>) myMatches.SyncRoot;
            return result;
        }
            public static int Search(int[] nums, int target)
            {
                int counter, result;
                
                return -1;

            }
   
        public static double myPow(double x, int n)
        {
            if (n == 0) return 1;
            double baseNumber, result = 1.0;
            int power;
            
            if (n < 0)
            {
                power = -1 * n;
                baseNumber = 1.0 / x;
            }
            else
            {
                power = n;
                baseNumber = x;
            }
            while (power > 0 && result < double.MaxValue && result > double.MinValue && Math.Abs(result) > double.Epsilon) { 
                result *= baseNumber;
                power--;
            }
            return result;
        }
    }
}
