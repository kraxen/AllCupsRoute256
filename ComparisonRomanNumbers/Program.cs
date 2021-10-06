using System;

namespace ComparisonRomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n1 = ParseRoman(inputs[0]);
            int n2 = ParseRoman(inputs[1]);

            if (n1 == n2)
            {
                Console.WriteLine("0");
            }
            else if (n1 > n2)
            {
                Console.WriteLine("1");
            }
            else Console.WriteLine("-1");

        }


        static int ParseRoman(string romanNumber)
        {
            int intNumber = 0;

            var c = romanNumber.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 'M') intNumber += 1000;
                else if (c[i] == 'D') intNumber += 500;
                else if (c[i] == 'C')
                {
                    if (i + 1 < c.Length)
                    {
                        if (c[i + 1] == 'D') { intNumber += 400; i++; continue; }
                        else if (c[i + 1] == 'M') { intNumber += 900; i++; continue; }
                        else { intNumber += 100; }
                    }
                }
                else if (c[i] == 'L') intNumber += 50;
                else if (c[i] == 'X')
                {
                    if (i + 1 < c.Length)
                    {
                        if (c[i + 1] == 'L') { intNumber += 40; i++; continue; }
                        else if (c[i + 1] == 'C') { intNumber += 90; i++; continue; }
                        else { intNumber += 10; }
                    }
                }
                else if (c[i] == 'V') intNumber += 5;
                else if (c[i] == 'I')
                {
                    if (i + 1 < c.Length)
                    {
                        if (c[i + 1] == 'X') { intNumber += 9; i++; continue; }
                        else if (c[i + 1] == 'V') { intNumber += 4; i++; continue; }
                        else { intNumber += 1; }
                    }
                }
            }
            return intNumber;
        }
    }
}
