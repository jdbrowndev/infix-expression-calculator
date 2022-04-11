using System;
using Xunit;
using InfixExpressionCalculator.Library;

namespace InfixExpressionCalculator.Tests;

public class The_InfixToPostfix_Method
{
	[Theory]
	[InlineData("10 * (5 + 5)", "10 5 5 + *")]
	public void Should_Handle_Parentheses_Before_Multiplication(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("10 / 5 * 2", "10 5 2 * /")]
	public void Should_Handle_Multiplication_Before_Division(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("5 + 10 / 10", "5 10 10 / +")]
	public void Should_Handle_Division_Before_Addition(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("10 - 5 + 5", "10 5 5 + -")]
	public void Should_Handle_Addition_Before_Subtraction(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("120", "120")]
	[InlineData("(120)", "120")]
	public void Should_Return_The_Number_If_A_Single_Number_Is_Given(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("12 0", "120")]
	[InlineData("2 + 5 2 + 1 3 2", "2 52 + 132 +")]
	[InlineData("2 .2 + 4 .4", "2.2 4.4 +")]
	public void Should_Concatenate_Adjacent_Numbers(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData("(5)(6)", "56")]
	[InlineData("(((((5)))))(6)((7))(((8)))", "5678")]
	[InlineData("((1))(2) + 1", "12 1 +")]
	public void Should_Concatenate_Adjacent_Numbers_In_Parentheses(string infix, string postfix)
	{
		Assert.Equal(postfix, Calculator.InfixToPostfix(infix));
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData("\t")]
	public void Should_Throw_Exception_If_Expression_Is_Empty(string infix)
	{
		var exception = Assert.Throws<ArgumentException>(() => Calculator.InfixToPostfix(infix));
		Assert.Equal("Expression is empty.", exception.Message);
	}

	[Theory]
	[InlineData("5 + 5)")]
	[InlineData("(5 + (5 + 5))) + (5 + 5)")]
	public void Should_Throw_Exception_If_Left_Parenthesis_Is_Missing(string infix)
	{
		var exception = Assert.Throws<Exception>(() => Calculator.InfixToPostfix(infix));
		Assert.Equal("Missing ( parenthesis.", exception.Message);
	}

	[Theory]
	[InlineData("(5 + 5")]
	[InlineData("(5 + (5 + 5) + (5 + 5)")]
	public void Should_Throw_Exception_If_Right_Parenthesis_Is_Missing(string infix)
	{
		var exception = Assert.Throws<Exception>(() => Calculator.InfixToPostfix(infix));
		Assert.Equal("Missing ) parenthesis.", exception.Message);
	}

	[Theory]
	[InlineData("5 + - 5")]
	[InlineData("(5 * 5) - 2 + - 3")]
	[InlineData("2 * 3 / 4 - 5 + 1 + - 6 + 7 * 3")]
	public void Should_Throw_Exception_If_Two_Operators_Are_Adjacent(string infix)
	{
		var exception = Assert.Throws<Exception>(() => Calculator.InfixToPostfix(infix));
		Assert.Equal("Operators + and - are adjacent.", exception.Message);
	}
}