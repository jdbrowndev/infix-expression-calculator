using System;
using Xunit;

namespace InfixExpressionCalculator.Tests;

public class The_EvaluatePostfix_Method
{
	[Theory]
	[InlineData("2 2 +", 4.0)]
	[InlineData("5 7 + 12 - 100 * 1 +", 1.0)]
	[InlineData("2 9.1 3 + *", 24.2)]
	public void Should_Evaluate_A_Postfix_Expression_Correctly(string postfix, decimal output)
	{
		Assert.Equal(output, InfixExpressionCalculator.EvaluatePostfix(postfix), 4);
	}

	[Theory]
	[InlineData("120", 120.0)]
	public void Should_Return_The_Number_If_A_Single_Number_Is_Given(string postfix, decimal output)
	{
		Assert.Equal(output, InfixExpressionCalculator.EvaluatePostfix(postfix), 4);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("\t")]
	public void Should_Throw_Exception_If_Expression_Is_Empty(string postfix)
	{
		var exception = Assert.Throws<ArgumentException>(() => InfixExpressionCalculator.EvaluatePostfix(postfix));
		Assert.Equal("Expression is empty.", exception.Message);
	}

	[Theory]
	[InlineData("2 0 /")]
	public void Should_Throw_Exception_When_Dividing_By_Zero(string postfix)
	{
		Assert.Throws<DivideByZeroException>(() => InfixExpressionCalculator.EvaluatePostfix(postfix));
	}

	[Theory]
	[InlineData("+")]
	[InlineData("+ 2")]
	[InlineData("2 +")]
	[InlineData("2 2 + +")]
	public void Should_Throw_Exception_When_Given_A_Postfix_Expression_With_Too_Many_Operators(string postfix)
	{
		var exception = Assert.Throws<Exception>(() => InfixExpressionCalculator.EvaluatePostfix(postfix));
		Assert.Equal("Too many operators.", exception.Message);
	}

	[Theory]
	[InlineData("2 3a +")]
	public void Should_Throw_Exception_When_Given_A_Postfix_Expression_With_Invalid_Numbers(string postfix)
	{
		var exception = Assert.Throws<Exception>(() => InfixExpressionCalculator.EvaluatePostfix(postfix));
		Assert.Equal("3a is not a valid number.", exception.Message);
	}

	[Fact]
	public void Should_Throw_Exception_On_Positive_Decimal_Overflow()
	{
		Assert.Throws<OverflowException>(() => InfixExpressionCalculator.EvaluatePostfix(String.Format("{0} 1 +", Decimal.MaxValue)));
	}

	[Fact]
	public void Should_Throw_Exception_On_Negative_Decimal_Overflow()
	{
		Assert.Throws<OverflowException>(() => InfixExpressionCalculator.EvaluatePostfix(String.Format("{0} 1 -", -Decimal.MaxValue)));
	}
}
