using System;
using NUnit.Framework;

namespace InfixExpressionCalculator.Tests
{
    [TestFixture]
    public class The_InfixToPostfix_Method
    {
        [TestCase("10 * (5 + 5)", "10 5 5 + *")]
        public void Should_Handle_Parentheses_Before_Multiplication(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [TestCase("10 / 5 * 2", "10 5 2 * /")]
        public void Should_Handle_Multiplication_Before_Division(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [TestCase("5 + 10 / 10", "5 10 10 / +")]
        public void Should_Handle_Division_Before_Addition(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [TestCase("10 - 5 + 5", "10 5 5 + -")]
        public void Should_Handle_Addition_Before_Subtraction(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [TestCase("120", "120")]
        [TestCase("(120)", "120")]
        public void Should_Return_The_Number_If_A_Single_Number_Is_Given(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [TestCase("12 0", "120")]
        [TestCase("2 + 5 2 + 1 3 2", "2 52 + 132 +")]
        [TestCase("2 .2 + 4 .4", "2.2 4.4 +")]
        public void Should_Concatenate_Adjacent_Numbers(string infix, string postfix)
        {
            Assert.That(InfixExpressionCalculator.InfixToPostfix(infix), Is.EqualTo(postfix));
        }

        [Test]
        [ExpectedException(typeof (Exception), ExpectedMessage = "Expression is empty.")]
        public void Should_Throw_Exception_If_Expression_Is_Empty()
        {
            InfixExpressionCalculator.InfixToPostfix("");
        }

        [TestCase("5 + 5)")]
        [TestCase("(5 + (5 + 5))) + (5 + 5)")]
        [ExpectedException(typeof (Exception), ExpectedMessage = "Missing ( parenthesis.")]
        public void Should_Throw_Exception_If_Left_Parenthesis_Is_Missing(string infix)
        {
            InfixExpressionCalculator.InfixToPostfix(infix);
        }

        [TestCase("(5 + 5")]
        [TestCase("(5 + (5 + 5) + (5 + 5)")]
        [ExpectedException(typeof (Exception), ExpectedMessage = "Missing ) parenthesis.")]
        public void Should_Throw_Exception_If_Right_Parenthesis_Is_Missing(string infix)
        {
            InfixExpressionCalculator.InfixToPostfix(infix);
        }

        [TestCase("5 + - 5")]
        [TestCase("(5 * 5) - 2 + - 3")]
        [TestCase("2 * 3 / 4 - 5 + 1 + - 6 + 7 * 3")]
        [ExpectedException(typeof (Exception),
            ExpectedMessage = "Operators + and - are adjacent.")]
        public void Should_Throw_Exception_If_Two_Operators_Are_Adjacent(string infix)
        {
            InfixExpressionCalculator.InfixToPostfix(infix);
        }
    }
}