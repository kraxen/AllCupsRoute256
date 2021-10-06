using System;

namespace CapitalizedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().ToLower().Split(' ');

            string res = "";

            for (int i = 0; i < inputs.Length; i++)
            {
                char[] vs = inputs[i].ToCharArray();
                string svs = "";
                try
                {
                    svs = vs?[0].ToString();
                }
                catch
                {

                }
                svs = svs.ToUpper();
                for (int j = 1; j < vs.Length; j++)
                {
                    svs += vs[j];
                }
                res += svs + " ";
            }

            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
