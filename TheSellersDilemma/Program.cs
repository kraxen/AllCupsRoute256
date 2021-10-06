using System;
using System.Collections.Generic;

namespace TheSellersDilemma
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            List<int> money = new List<int>();

            for (int i = 0; i < inputs.Length; i++)
            {
                money.Add(Int32.Parse(inputs[i]));
            }
            if (СanGiveChange(money)) Console.WriteLine("True");
            else Console.WriteLine("False");
        }
        static bool СanGiveChange(List<int> moneyBuyers)
        {
            Dictionary<int, int> moneySeller = new Dictionary<int, int>();
            foreach (int item in moneyBuyers)
            {
                switch (item)
                {
                    case 1000:
                        {
                            AddCountBills(ref moneySeller, item);
                            break;
                        };
                    case 2000:
                        {
                            if ((moneySeller.ContainsKey(1000)) && (moneySeller[1000] >= 1))
                            {
                                AddCountBills(ref moneySeller, item);
                                ReduceCountBills(ref moneySeller, 1000, 1);
                            }
                            else { return false; }
                            break;
                        }
                    case 5000:
                        {
                            if ((moneySeller.ContainsKey(2000)) && (moneySeller[2000] >= 2))
                            {
                                AddCountBills(ref moneySeller, item);
                                ReduceCountBills(ref moneySeller, 2000, 2);
                            }
                            else if (moneySeller.ContainsKey(1000) && moneySeller.ContainsKey(2000) && (moneySeller[2000] >= 1) && (moneySeller[1000] >= 2))
                            {
                                AddCountBills(ref moneySeller, item);
                                ReduceCountBills(ref moneySeller, 1000, 2);
                                ReduceCountBills(ref moneySeller, 2000, 1);
                            }
                            else if (moneySeller.ContainsKey(1000) && (moneySeller[1000] >= 4))
                            {
                                AddCountBills(ref moneySeller, item);
                                ReduceCountBills(ref moneySeller, 1000, 4);
                            }
                            else { return false; }
                            break;
                        }
                }
            }
            return true;
        }
        /// <summary>
        /// Уменьшение кол-ва купюр в кассе на определенное кол-во
        /// </summary>
        /// <param name="cashBox">Касса</param>
        /// <param name="denomination">Номинал купюры</param>
        /// <param name="denominationCount">Кол-во, на которое нужно уменьшить</param>
        static void ReduceCountBills(ref Dictionary<int, int> cashBox, int denomination, int denominationCount)
        {
            int count;
            cashBox.TryGetValue(denomination, out count);
            count -= denominationCount;
            cashBox.Remove(denomination);
            cashBox.Add(denomination, count);
        }
        /// <summary>
        /// Увеличение кол-ва купюр в кассе на 1
        /// </summary>
        /// <param name="cashBox">Касса</param>
        /// <param name="denomination">Номинал купюры</param>
        static void AddCountBills(ref Dictionary<int, int> cashBox, int denomination)
        {
            int count;
            cashBox.TryGetValue(denomination, out count);
            count++;
            cashBox.Remove(denomination);
            cashBox.Add(denomination, count);
        }
    }
}
