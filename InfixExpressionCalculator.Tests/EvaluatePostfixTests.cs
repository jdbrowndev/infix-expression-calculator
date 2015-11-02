using System;
using NUnit.Framework;

namespace InfixExpressionCalculator.Tests
{
    [TestFixture]
    public class The_EvaluatePostfix_Method
    {
        [TestCase("2 2 +", 4.0)]
        [TestCase("5 7 + 12 - 100 * 1 +", 1.0)]
        [TestCase("2 9.1 3 + *", 24.2)]
        public void Should_Evaluate_A_Postfix_Expression_Correctly(string postfix, decimal output)
        {
            Assert.That(InfixExpressionCalculator.EvaluatePostfix(postfix), Is.EqualTo(output).Within(.001));
        }

        [TestCase("120", 120.0)]
        public void Should_Return_The_Number_If_A_Single_Number_Is_Given(string postfix, decimal output)
        {
            Assert.That(InfixExpressionCalculator.EvaluatePostfix(postfix), Is.EqualTo(output).Within(.001));
        }

        [Test]
        [ExpectedException(typeof (Exception), ExpectedMessage = "Expression is empty.")]
        public void Should_Throw_Exception_If_Expression_Is_Empty()
        {
            InfixExpressionCalculator.EvaluatePostfix("");
        }

        [TestCase("2 0 /")]
        [ExpectedException(typeof (DivideByZeroException))]
        public void Should_Throw_Exception_When_Dividing_By_Zero(string postfix)
        {
            InfixExpressionCalculator.EvaluatePostfix(postfix);
        }

        [TestCase("+")]
        [TestCase("+ 2")]
        [TestCase("2 +")]
        [TestCase("2 2 + +")]
        [ExpectedException(typeof (Exception), ExpectedMessage = "Too many operators.")]
        public void Should_Throw_Exception_When_Given_A_Postfix_Expression_With_Too_Many_Operators(string postfix)
        {
            InfixExpressionCalculator.EvaluatePostfix(postfix);
        }

        [TestCase("2 3a +")]
        [ExpectedException(typeof (Exception), ExpectedMessage = "3a is not a valid number.")]
        public void Should_Throw_Exception_When_Given_A_Postfix_Expression_With_Invalid_Numbers(string postfix)
        {
            InfixExpressionCalculator.EvaluatePostfix(postfix);
        }

        [Test]
        [ExpectedException(typeof (OverflowException))]
        public void Should_Throw_Exception_On_Positive_Decimal_Overflow()
        {
            InfixExpressionCalculator.EvaluatePostfix(String.Format("{0} 1 +", Decimal.MaxValue));
        }

        [Test]
        [ExpectedException(typeof (OverflowException))]
        public void Should_Throw_Exception_On_Negative_Decimal_Overflow()
        {
            InfixExpressionCalculator.EvaluatePostfix(String.Format("{0} 1 -", -Decimal.MaxValue));
        }
    }
}