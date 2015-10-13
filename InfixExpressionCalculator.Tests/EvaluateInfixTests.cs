using NUnit.Framework;

namespace InfixExpressionCalculator.Tests
{
    [TestFixture]
    public class The_EvaluateInfix_Method
    {
        [TestCase("2 + 2", 4.0)]
        [TestCase("5 * (2 + 2)", 20.0)]
        public void Should_Evaluate_An_Infix_Expression_Correctly(string infix, decimal output)
        {
            Assert.That(InfixExpressionCalculator.EvaluateInfix(infix), Is.EqualTo(output).Within(.001));
        }
    }
}