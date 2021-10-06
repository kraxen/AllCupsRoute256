using System;
using System.Collections.Generic;

namespace CountFreeIPAdresses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            string[] ipAdressString1 = inputs[0].Split('.');
            string[] ipAdressString2 = inputs[1].Split('.');

            List<int> ipAdress1 = new List<int>();
            List<int> ipAdress2 = new List<int>();

            double count = 0;

            for (int i = 0; i < ipAdressString1.Length; i++)
            {
                ipAdress1.Add(Int32.Parse(ipAdressString1[i]));
                ipAdress2.Add(Int32.Parse(ipAdressString2[i]));
            }

            for (int i = 0, j = 3; i < 4; i++, j--)
            {
                count += (ipAdress2[j] - ipAdress1[j]) * Math.Pow(256, i);
            }

            Console.WriteLine(count);
        }
    }
}
