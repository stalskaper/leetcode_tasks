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
        public static Dictionary<char, int> chfrToDigit = new Dictionary<char, int>()
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
            int counter = 0;
            int result = Int32.MaxValue;
            char[] toProcess = str.Trim().Split(' ').FirstOrDefault(a=>a.All(c => Char.IsDigit(c) || c == '-')).Trim().ToCharArray();
            bool sign = toProcess[0] == '-';
            if ((toProcess.Length)<10)
            {
                do
                {
                    if (toProcess.Length>0)
                        counter++;
                } while (counter < toProcess.Length);
            }
            return 0;
        }

    }
}
