using System;

namespace InfixExpressionCalculator.CLI
{
    /// <summary>
    /// A small command-line interface for InfixExpressionCalculator.
    /// </summary>
    internal static class Program
    {
        internal static void Main()
        {
            Console.WriteLine("When done, enter 'exit' to quit the calculator.");
            while (true)
            {
                Console.Write("Enter an infix expression: ");
                string input = Console.ReadLine(), output;
                if (input.ToLower().Equals("exit")) break;
                try
                {
                    output = InfixExpressionCalculator.EvaluateInfix(input).ToString();
                }
                catch (Exception e)
                {
                    output = "Invalid expression: " + e.Message;
                }
                Console.WriteLine("=> {0}\n", output);
            }
        }
    }
}