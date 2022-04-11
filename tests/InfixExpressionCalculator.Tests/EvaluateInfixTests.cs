using InfixExpressionCalculator.Library;
using Xunit;

namespace InfixExpressionCalculator.Tests;

public class The_EvaluateInfix_Method
{
	[Theory]
	[InlineData("2 + 2", 4.0)]
	[InlineData("2", 2.0)]
	[InlineData("5 + 5 - 2", 8.0)]
	[InlineData("5 - 2 + 12 / 2 * 3", 1.0)]
	[InlineData("(5 * 2) + 2", 12.0)]
	[InlineData("5 * (2 + 2)", 20.0)]
	[InlineData("(5 * 2) + (5 * 3)", 25.0)]
	[InlineData("((5 * 2) + (5 * 3))", 25.0)]
	[InlineData("(5 * (2 + 5) * 3)", 105.0)]
	[InlineData("4.47 + 1.02 * 3", 7.53)]
	[InlineData("5.0214 / 6.2033", .8095)]
	[InlineData("1.00000001 * (2.093198 + 5.3232234) - 9.24 / 7", 6.0964)]
	[InlineData("0 - 100", -100)]
	[InlineData("8 + (2 - 12)", -2)]
	[InlineData("8 / (0 - 2)", -4)]
	[InlineData("8 * (0 - 3)", -24)]
	[InlineData("8.65468 - 6.65465 - 2.65654", -0.65651)]
	public void Should_Evaluate_An_Infix_Expression_Correctly(string infix, decimal output)
	{
		Assert.Equal(output, Calculator.EvaluateInfix(infix), 4);
	}
}