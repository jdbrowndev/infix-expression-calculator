# infix-expression-calculator

This C# solution contains a calculator for evaluating infix expressions. Infix expressions are arithmetic expressions written in traditional notation, such as (2+3)-4.

The solution is comprised of 3 projects:

- `InfixExpressionCalculator.Library` - Contains a `Calculator` class for evaluating infix expressions. The [shunting-yard algorithm](https://wikipedia.org/wiki/Shunting-yard_algorithm) is used to convert an infix expression to a postfix expression. A postfix expression can then be evaluated via a stack.

- `InfixExpressionCalculator.Console` - Launches the calculator via a command-line interface.

- `InfixExpressionCalculator.Tests` - Contains xUnit tests of the `InfixExpressionCalculator.Library` project.

# Installation

.NET 6 SDK must be installed to run the calculator and its tests.

To run the calculator:

```
cd .\src\InfixExpressionCalculator.Console\
dotnet run
```

To run all tests:

```
cd .\tests\InfixExpressionCalculator.Tests\
dotnet test
```

# Notes

- Supported operators include `*`, `/`, `+`, and `-`. `(` and `)` parentheses are also supported.

  - Note that the `-` operator cannot be used to negate a number. A different operator would be required to implement this.
  
- Since a traditional calculator does not allow spaces, the program will remove spaces before processing an infix expression. This means that numbers separated by spaces will be concatenated together. For example, `20 15` would be parsed as `2015`.

- For simplicity, adjacent numbers in parentheses are concatenated rather than multiplied. For example, `(5)(6)` would be parsed as `56` rather than `5*6`.

# License

See LICENSE.