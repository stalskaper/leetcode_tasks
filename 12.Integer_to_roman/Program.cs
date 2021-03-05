using System;

namespace _12.Integer_to_roman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 9; i++)
            {
                int t = int.Parse(Console.ReadLine());
                Console.WriteLine(IntToRoman(t));
                Console.ReadKey();
            }
        }

        public static string IntToRoman(int num)
        {
            string result = default;
            if (num <= 3999 && num >= 1000) 
            { 
                result += ProcessThousand(num);
                num -= 1000 * (num / 1000);
            }
            if (num <= 999 && num >= 100)
            {
                result += ProcessHundreds(num, 100, 'C', 'D', 'M');
                num -= 100 * (num / 100);
            }
            if (num <= 99 && num >= 10)
            {
                result += ProcessHundreds(num, 10, 'X', 'L', 'C');
                num -= 10 * (num / 10);
            }
            if (num <= 9 && num >= 1)
            {
                result += ProcessHundreds(num, 1, 'I', 'V', 'X');                
            }
            return result;
        }

        public static string ProcessThousand(int num)
        {
            return new string('M', num / 1000);
        }

        public static string ProcessHundreds(int num, int baseValue, char unit, char halfdecade, char decade )
        {
            int hundreds = num / baseValue;
            if (hundreds < 1) return string.Empty;
            if (hundreds < 4) return new string(unit, hundreds);
            if (hundreds == 4) return $"{unit}{halfdecade}";
            if (hundreds == 5) return halfdecade.ToString();
            if (hundreds < 9) return $"{halfdecade}{new string(unit, (hundreds - 5))}";
            if (hundreds == 9) return $"{unit}{decade}";
            return string.Empty;
        }
    }
}
