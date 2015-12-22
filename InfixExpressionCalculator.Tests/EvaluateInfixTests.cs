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
        [TestCase("4.47 + 1.02 * 3", 7.53)]
        [TestCase("5.0214 / 6.2033", .8095)]
        [TestCase("1.00000001 * (2.093198 + 5.3232234) - 9.24 / 7", 6.0964)]
        [TestCase("0 - 100", -100)]
        [TestCase("8 + (2 - 12)", -2)]
        [TestCase("8 / (0 - 2)", -4)]
        [TestCase("8 * (0 - 3)", -24)]
        [TestCase("8.65468 - 6.65465 - 2.65654", -0.65651)]
        public void Should_Evaluate_An_Infix_Expression_Correctly(string infix, decimal output)
        {
            Assert.That(InfixExpressionCalculator.EvaluateInfix(infix), Is.EqualTo(output).Within(.001));
        }
    }
}