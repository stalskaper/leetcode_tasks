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
            bool nonWhiteSpaceAppeared = false;
            bool trailingNullsAppeared = false;
            int result = 0;
            int counter = 0;
            sign sign = sign.unassigned;
            while (counter < str.Length)
            {
                if (str[counter] == ' ')
                {
                    if (nonWhiteSpaceAppeared)
                    {
                        finishPosition = counter - 1;
                        break;
                    }
                    counter++;
                }
                else if (signChars.Contains(str[counter]))
                {
                    if (startPosition > -1)
                    {
                        finishPosition = counter - 1;
                        break;
                    }
                    else if (trailingNullsAppeared) return 0;                    
                    nonWhiteSpaceAppeared = true;
                    if (sign != sign.unassigned) return 0;
                    else sign = str[counter] == '+' ? sign.positive : sign.negative;
                    counter++;
                    continue;
                }
                else if (charToDigit.ContainsKey(str[counter]))
                {
                    nonWhiteSpaceAppeared = true;
                    if (str[counter] != '0' && startPosition == -1)
                    {
                        startPosition = counter;
                    }
                    else
                    {
                        trailingNullsAppeared = true;
                    }
                    counter++;
                    continue;
                }
                else
                {
                    if (startPosition > -1) finishPosition = counter - 1;
                    break;
                }              
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
                return sign == sign.negative ? (-1) * result : result;
            }
            else
            {
                return parseMax(parsebleArray, sign != sign.negative);
            }
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

        public static int parseMax(char[] parsedString, bool positive = true)
        {
            if (parsedString.Length > 10) return positive ? Int32.MaxValue : Int32.MinValue;
            bool hasGap = false;
            Int32 result = 0;
            for (int i = 0; i < parsedString.Length - 1; i++)
            {
                if (charToDigit[parsedString[i]] < charToDigit[limitValue[i]]) hasGap = true;
                if (charToDigit[parsedString[i]] > charToDigit[limitValue[i]] && !hasGap) return positive ? Int32.MaxValue : Int32.MinValue;
                else
                    result += myPow(10, parsedString.Count() - i - 1) * (charToDigit[parsedString[i]]);
            }
            if (positive) 
            {
                if (!hasGap && (charToDigit[parsedString.Last()] > charToDigit[limitValue.Last()] - 1)) return Int32.MaxValue;
                else
                    result += (charToDigit[parsedString.Last()]);
            }
            else 
            {
                result = (-1) * result;
                if (!hasGap && (charToDigit[parsedString.Last()] > charToDigit[limitValue.Last()])) return Int32.MinValue;
                else
                    result -= (charToDigit[parsedString.Last()]);
            }
            return result;
        }

        public enum sign
        {
            positive,
            unassigned,
            negative
        }
    }
}
