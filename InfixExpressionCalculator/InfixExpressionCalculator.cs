using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InfixExpressionCalculator
{
    /// <summary>
    /// Class containing methods for evaluating infix expressions. Infix expressions are arithmetic expressions 
    /// written in traditional notation, such as (2+3)-4.
    /// </summary>
    public static class InfixExpressionCalculator
    {
        /// <summary>
        /// Dictionary mapping operators to order of precedence. Larger integers indicate greater precedence.
        /// <br/><br/>
        /// Operators omitted by this dictionary are unsupported. Also note that the - operator cannot be used to 
        /// negate a number.
        /// </summary>
        private static readonly Dictionary<char, int> Operators = new Dictionary<char, int>
        {
            {'-', 1},
            {'+', 2},
            {'/', 3},
            {'*', 4}
        };

        /// <summary>
        /// Evaluates an infix expression by 1) converting it to a postfix expression and 2) evaluating the
        /// postfix expression.
        /// </summary>
        /// <param name="infix">A string infix expression.</param>
        /// <returns>A decimal storing the infix expression's evaluation.</returns>
        public static decimal EvaluateInfix(string infix)
        {
            return EvaluatePostfix(InfixToPostfix(infix));
        }

        # region InfixToPostfix

        /// <summary>
        /// Uses the shunting-yard algorithm to parse an infix expression and convert it to a postfix expression.
        /// </summary>
        /// <param name="infix">A string infix expression.</param>
        /// <returns>A string postfix expression.</returns>
        /// <exception cref="System.Exception">Thrown when the infix expression is invalid.</exception>
        public static string InfixToPostfix(string infix)
        {
            if (infix.Length == 0) throw new Exception("Expression is empty.");

            var operatorStack = new Stack<char>();
            var output = new StringBuilder();

            foreach (char token in Regex.Replace(infix, @"\s+", ""))
            {
                if (Operators.ContainsKey(token))
                {
                    HandleOperatorCase(token, operatorStack, output);
                }
                else
                    switch (token)
                    {
                        case '(':
                            operatorStack.Push(token);
                            break;
                        case ')':
                            HandleRightParenthesisCase(operatorStack, output);
                            break;
                        default:
                            // Token must be a number. Don't append a space since the number may have multiple digits.
                            output.Append(token);
                            break;
                    }
            }

            EmptyOperatorStack(operatorStack, output);

            return output.ToString();
        }

        private static void HandleOperatorCase(char token, Stack<char> operatorStack, StringBuilder output)
        {
            // The operator case is the only case where a space is appended to the output string ahead of
            // the next iteration. Thus, if the last character in the output string is a space, then two
            // operators must be adjacent to one another.
            if (output.Length > 0 && output[output.Length - 1] == ' ')
            {
                throw new Exception(String.Format(
                    "Operators {0} and {1} are adjacent.", operatorStack.Peek(), token));
            }

            // Pop operators off the stack that have greater or equal precedence than token and append them to
            // the output string. Then push token onto the stack. Note that a left parenthesis on the stack
            // will stop the loop.
            while (operatorStack.Count > 0 && Operators.ContainsKey(operatorStack.Peek()) &&
                   Operators[operatorStack.Peek()] >= Operators[token])
            {
                output.Append(" ").Append(operatorStack.Pop());
            }

            output.Append(" ");
            operatorStack.Push(token);
        }

        private static void HandleRightParenthesisCase(Stack<char> operatorStack, StringBuilder output)
        {
            // Until a matching left parenthesis is found, pop operators off the stack and append them
            // to the output string. When the matching left parenthesis is found, pop it off the stack
            // but do not append it to the output string.
            while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
            {
                output.Append(" ").Append(operatorStack.Pop());
            }
            if (operatorStack.Count == 0)
            {
                throw new Exception("Missing ( parenthesis.");
            }
            operatorStack.Pop();
        }

        private static void EmptyOperatorStack(Stack<char> operatorStack, StringBuilder output)
        {
            // At the end of the algorithm, remaining operators should be popped off the stack and appended to
            // the output string. If a left parenthesis is still on the stack, then a right parenthesis is missing.
            while (operatorStack.Count > 0)
            {
                if (operatorStack.Peek() == '(')
                {
                    throw new Exception("Missing ) parenthesis.");
                }
                output.Append(" ").Append(operatorStack.Pop());
            }
        }

        #endregion

        #region EvaluatePostfix

        /// <summary>
        /// Uses a stack to evaluate a postfix expression to a number.
        /// </summary>
        /// <param name="postfix">A string postfix expression.</param>
        /// <returns>A decimal storing the postfix expression's evaluation.</returns>
        /// <exception cref="System.Exception">Thrown when the postfix expression is invalid.</exception>
        /// <exception cref="System.DivideByZeroException">Thrown when the postfix expression divides by 0.</exception>
        public static decimal EvaluatePostfix(string postfix)
        {
            if (postfix.Length == 0) throw new Exception("Expression is empty.");

            var stack = new Stack<decimal>();

            foreach (string token in Regex.Split(postfix.Trim(), @"\s+"))
            {
                if (token.Length == 1 && Operators.ContainsKey(token[0]))
                {
                    if (stack.Count < 2) throw new Exception("Too many operators.");
                    decimal operand2 = stack.Pop(), operand1 = stack.Pop();
                    ApplyOperatorToOperands(token[0], operand1, operand2, stack);
                }
                else
                {
                    try
                    {
                        // Token must be a number.
                        stack.Push(Decimal.Parse(token));
                    }
                    catch (FormatException)
                    {
                        throw new Exception(String.Format("{0} is not a valid number.", token));
                    }
                }
            }

            return stack.Pop();
        }

        private static void ApplyOperatorToOperands(char token, decimal operand1, decimal operand2, Stack<decimal> stack)
        {
            switch (token)
            {
                case '-':
                    stack.Push(operand1 - operand2);
                    break;
                case '+':
                    stack.Push(operand1 + operand2);
                    break;
                case '/':
                    if (operand2 == 0) throw new DivideByZeroException();
                    stack.Push(operand1/operand2);
                    break;
                case '*':
                    stack.Push(operand1*operand2);
                    break;
                default:
                    throw new Exception(
                        String.Format("{0} is an unsupported operator.", token));
            }
        }

        #endregion
    }
}