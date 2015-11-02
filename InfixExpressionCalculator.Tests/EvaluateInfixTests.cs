using NUnit.Framework;

namespace InfixExpressionCalculator.Tests
{
    [TestFixture]
    public class The_EvaluateInfix_Method
    {
        [TestCase("2", 2.0)]
        [TestCase("2 + 2", 4.0)]
        [TestCase("5 + 5 - 2", 8.0)]
        [TestCase("5 - 2 + 12 / 2 * 3", 1.0)]
        [TestCase("(5 * 2) + 2", 12.0)]
        [TestCase("5 * (2 + 2)", 20.0)]
        [TestCase("(5 * 2) + (5 * 3)", 25.0)]
        [TestCase("((5 * 2) + (5 * 3))", 25.0)]
        [TestCase("(5 * (2 + 5) * 3)", 105.0)]
        public void Should_Evaluate_An_Infix_Expression_Correctly(string infix, decimal output)
        {
            Assert.That(InfixExpressionCalculator.EvaluateInfix(infix), Is.EqualTo(output).Within(.001));
        }
    }
}