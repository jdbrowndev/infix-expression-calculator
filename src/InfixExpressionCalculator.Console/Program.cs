using InfixExpressionCalculator.Library;

Console.WriteLine("When done, enter 'exit' to quit the calculator.");
while (true)
{
	string output;
	try
	{
		Console.Write("Enter an infix expression: ");
		string input = Console.ReadLine();

		if (input.ToLower().Equals("exit"))
			break;

		output = Calculator.EvaluateInfix(input).ToString();
	}
	catch (Exception e)
	{
		output = $"Invalid expression: {e.Message}";
	}
	Console.WriteLine($"=> {output}\n");
}