using System;
using System.Collections.Generic;

namespace EvaluatingBooleanExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            string boolExpression = inputs[0];

            Dictionary<string, bool> variables = new Dictionary<string, bool>();
            variables.Add("True", true);
            variables.Add("False", false);

            for (int i = 1; i < inputs.Length - 1; i += 2)
            {
                variables.Add(inputs[i], Boolean.Parse(inputs[i + 1]));
            }
            if (boolExpression.Length == 1)
            {
                bool temp;
                variables.TryGetValue(boolExpression[0].ToString(), out temp);
                if (temp) boolExpression = boolExpression.Substring(0, 0) + "True";
                else boolExpression = boolExpression.Substring(0, 0) + "False";
            }
            while ((boolExpression != "True") && (boolExpression != "False"))
            {
                while (boolExpression.Contains("!"))
                {
                    var operationIndex = boolExpression.IndexOf("!"); // Находим индекс операции
                    string operationValue = boolExpression[operationIndex + 1].ToString(); // Находим значение операции
                    if ((operationValue == "T") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'r')) operationValue = "True";
                    else if ((operationValue == "F") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'a')) operationValue = "False";
                    bool temp = variables[operationValue];
                    if (operationValue == "True")
                        boolExpression = boolExpression.Substring(0, operationIndex) + "False" + boolExpression.Substring(operationIndex + 5);
                    else if (operationValue == "False")
                        boolExpression = boolExpression.Substring(0, operationIndex) + "True" + boolExpression.Substring(operationIndex + 6);
                    else if (temp)
                        boolExpression = boolExpression.Substring(0, operationIndex) + "False" + boolExpression.Substring(operationIndex + 2);
                    else
                        boolExpression = boolExpression.Substring(0, operationIndex) + "True" + boolExpression.Substring(operationIndex + 2);
                }
                while (boolExpression.Contains("&"))
                {
                    var operationIndex = boolExpression.IndexOf("&");
                    var operationValue1 = boolExpression[operationIndex - 1].ToString();
                    if ((operationValue1 == "e") && (operationIndex - 2 >= 0))
                    {
                        if (boolExpression[operationIndex - 2] == 'u') operationValue1 = "True";
                        else if (boolExpression[operationIndex - 2] == 's') operationValue1 = "False";
                    }
                    var operationValue2 = boolExpression[operationIndex + 1].ToString();
                    if ((operationValue2 == "T") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'r')) operationValue2 = "True";
                    else if ((operationValue2 == "F") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'a')) operationValue2 = "False";
                    bool temp1 = variables[operationValue1];
                    bool temp2 = variables[operationValue2];
                    if ((operationValue1 == "True") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "True") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "False" + boolExpression.Substring(operationIndex + 6);
                    else if ((operationValue1 == "False") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "False") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 6);
                    else if (operationValue1 == "True")
                    {
                        if (true && temp2) boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 2);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 4) + "False" + boolExpression.Substring(operationIndex + 2);
                    }
                    else if (operationValue1 == "False") boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 2);
                    else if (operationValue2 == "True")
                    {
                        if (temp1 && true) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 5);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 6);
                    }
                    else if (operationValue2 == "False") boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 6);
                    else if (temp1 && temp2) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 2);
                    else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 2);
                }
                while (boolExpression.Contains("|"))
                {
                    var operationIndex = boolExpression.IndexOf("|");
                    var operationValue1 = boolExpression[operationIndex - 1].ToString();
                    if ((operationValue1 == "e") && (operationIndex - 2 >= 0))
                    {
                        if (boolExpression[operationIndex - 2] == 'u') operationValue1 = "True";
                        else if (boolExpression[operationIndex - 2] == 's') operationValue1 = "False";
                    }
                    var operationValue2 = boolExpression[operationIndex + 1].ToString();
                    if ((operationValue2 == "T") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'r')) operationValue2 = "True";
                    else if ((operationValue2 == "F") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'a')) operationValue2 = "False";
                    bool temp1 = variables[operationValue1];
                    bool temp2 = variables[operationValue2];
                    if ((operationValue1 == "True") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "True") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 6);
                    else if ((operationValue1 == "False") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "True" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "False") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 6);
                    else if (operationValue1 == "True") boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 2);
                    else if (operationValue1 == "False")
                    {
                        if (false || temp2) boolExpression = boolExpression.Substring(0, operationIndex - 5) + "True" + boolExpression.Substring(operationIndex + 2);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 2);
                    }
                    else if (operationValue2 == "True") boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 5);
                    else if (operationValue2 == "False")
                    {
                        if (temp1 || false) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 6);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 6);
                    }
                    else if (temp1 || temp2) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 2);
                    else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 2);
                }
                while (boolExpression.Contains("="))
                {
                    var operationIndex = boolExpression.IndexOf("=");
                    var operationValue1 = boolExpression[operationIndex - 1].ToString();
                    if ((operationValue1 == "e") && (operationIndex - 2 >= 0))
                    {
                        if (boolExpression[operationIndex - 2] == 'u') operationValue1 = "True";
                        else if (boolExpression[operationIndex - 2] == 's') operationValue1 = "False";
                    }
                    var operationValue2 = boolExpression[operationIndex + 1].ToString();
                    if ((operationValue2 == "T") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'r')) operationValue2 = "True";
                    else if ((operationValue2 == "F") && (operationIndex + 2 < boolExpression.Length) && (boolExpression[operationIndex + 2] == 'a')) operationValue2 = "False";
                    bool temp1 = variables[operationValue1];
                    bool temp2 = variables[operationValue2];
                    if ((operationValue1 == "True") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "True") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 4) + "False" + boolExpression.Substring(operationIndex + 6);
                    else if ((operationValue1 == "False") && (operationValue2 == "True"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 5);
                    else if ((operationValue1 == "False") && (operationValue2 == "False"))
                        boolExpression = boolExpression.Substring(0, operationIndex - 5) + "True" + boolExpression.Substring(operationIndex + 6);
                    else if (operationValue1 == "True")
                    {
                        if (true == temp2) boolExpression = boolExpression.Substring(0, operationIndex - 4) + "True" + boolExpression.Substring(operationIndex + 2);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 4) + "False" + boolExpression.Substring(operationIndex + 2);
                    }
                    else if (operationValue1 == "False")
                    {
                        if (false == temp2) boolExpression = boolExpression.Substring(0, operationIndex - 5) + "True" + boolExpression.Substring(operationIndex + 2);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 5) + "False" + boolExpression.Substring(operationIndex + 2);
                    }
                    else if (operationValue2 == "True")
                    {
                        if (temp1 == true) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 5);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 6);
                    }
                    else if (operationValue2 == "False")
                    {
                        if (temp1 == false) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 6);
                        else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 6);
                    }
                    else if (temp1 == temp2) boolExpression = boolExpression.Substring(0, operationIndex - 1) + "True" + boolExpression.Substring(operationIndex + 2);
                    else boolExpression = boolExpression.Substring(0, operationIndex - 1) + "False" + boolExpression.Substring(operationIndex + 2);
                }
            }
            Console.WriteLine(boolExpression);
        }
    }
}
