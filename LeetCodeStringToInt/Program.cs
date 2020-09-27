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
        public static int startPosition, finishPosition;
        public static char[] limitValue = new char[]{'2','1','4','7','4','8','3','6','4','8'};
        public static char[] signChars = new char[] { '+', '-' };
        public static Dictionary<char, int> charToDigit = new Dictionary<char, int>()
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9}
        };
        public static int MyAtoi(string str)
        {
            startPosition = -1; 
            finishPosition = -1;
            int result = 0;
            int counter = 0;
            sign sign = sign.unassigned;
            while (counter < str.Length)
            {
                if (signChars.Contains(str[counter]))
                {
                    if (sign == sign.unassigned)
                    { 
                        sign = (str[counter] == '+') ? sign.positive : sign.negative; 
                    }
                    else return 0;
                }

                if (startPosition == -1)
                {
                    if (str[counter] == '0') { counter++; continue; }
                    if (charToDigit.ContainsKey(str[counter]))
                    {
                        startPosition = counter;
                        if (sign == sign.unassigned) sign = sign.positive;
                    }
                }
                else
                if (!charToDigit.ContainsKey(str[counter]))
                {
                    finishPosition = counter - 1;
                    break;
                }
                counter++;
            }
            if (startPosition == -1) return 0;
            if (finishPosition == -1) finishPosition = str.Length - 1;
            char[] parsebleArray = str.Substring(startPosition, finishPosition - startPosition + 1).ToCharArray();
            counter = parsebleArray.Length;
            if (parsebleArray.Length < 10)
            {
                do
                {
                    if (!char.IsNumber(parsebleArray[counter - 1])) break;
                    result += myPow(10, parsebleArray.Count() - counter) * (charToDigit[parsebleArray[counter - 1]]);
                    counter--;
                } while (counter > 0);
                return sign == sign.positive ? result : (-1) * result;
            }
            else return sign== sign.positive ? parseMax(parsebleArray)*(-1) :  parseMax(parsebleArray);
        }

        public static Int32 myPow(int baseValue, int exponentValue)
        {
            if (exponentValue == 0)
            {
                return 1;
            }
            if (exponentValue == 1)
            {
                return baseValue;
            }
            return baseValue * myPow(baseValue, exponentValue - 1);
        }

        public static int parseMax(char[] parsedString)
        {
            if (parsedString.Length > 10) return Int32.MinValue;
            Int32 result = 0;
            for (int i = 0; i < parsedString.Length; i++)
            {
                if (charToDigit[parsedString[i]] > charToDigit[limitValue[i]]) return Int32.MaxValue;
                else
                    result -= myPow(10, parsedString.Count() - i - 1) * (charToDigit[parsedString[i]]);
            }
            return result;
        }

        public enum sign
        {
            positive,
            negative,
            unassigned
        }
    }
}
