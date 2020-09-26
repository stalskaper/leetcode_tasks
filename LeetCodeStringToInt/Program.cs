using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeStringToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string checkanswer = string.Empty;
            do
            {
                Console.WriteLine("Enter N to exit or string to process");
                checkanswer = Console.ReadLine();
                if (checkanswer != "N")
                {
                    Console.WriteLine(Solution.MyAtoi(checkanswer));
                }
            } while (checkanswer != "N");
        }
    }

    public static class Solution
    {
        public static char[] limitValue = new char[]{'2','1','4','7','4','8','3','6','4','8'};
        public static Dictionary<char, int> charToDigit = new Dictionary<char, int>()
        {
            { '0',0 },
            {'1',1 },
            { '2',2},
            { '3',3},
            { '4',4},
            { '5',5},
            { '6', 6},
            { '7', 7},
            { '8', 8},
            { '9', 9}
        };
        public static int MyAtoi(string str)
        {            
            int result = 0;
            List<char> toProcess = str.Trim().Split(' ').FirstOrDefault(a=>a.All(c => Char.IsDigit(c) || c == '-')).Trim().ToList<char>();
            bool sign = toProcess[0] == '-';
            if (sign)
            {
                toProcess.RemoveAt(0);
            }
            int counter = toProcess.Count();
            if ((toProcess.Count)<10)
            {
                do
                {
                    result+=(int)Math.Pow(10, toProcess.Count() - counter)*(charToDigit[toProcess[counter - 1]]);
                    counter--;
                } while (counter >0);
                return sign ? (-1)*result : result; 
            }
            return sign ? Int32.MinValue : Int32.MaxValue;
        }

    }
}
