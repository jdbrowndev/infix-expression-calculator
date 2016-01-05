# Overview

This C# solution contains a calculator for evaluating infix expressions. Infix expressions are arithmetic expressions written in traditional notation, such as (2+3)-4.

The solution is comprised of 3 Visual Studio projects:

- `InfixExpressionCalculator` - Contains methods for evaluating infix expressions. At the core of this project is the shunting-yard algorithm, which is used to convert an infix expression to a postfix expression that can be evaluated using a stack.

- `InfixExpressionCalculator.CLI` - Run this project to interact with the calculator via a command-line interface.

- `InfixExpressionCalculator.Tests` - Contains NUnit tests of the `InfixExpressionCalculator` project.

# Installation

Before installing, ensure that the following technologies are available on your machine:

- .NET Framework 4.5

- Visual Studio 2013 or equivalent

Download the repository by clicking "Download ZIP" on GitHub or by using a Git client to run the following:

`git clone https://github.com/emagdne/infix-expression-calculator.git`

Once downloaded, open `InfixExpressionCalculator.sln` in Visual Studio.

# Usage

To interact with the calculator, right-click on the `InfixExpressionCalculator.CLI` project and select `Set as StartUp Project`. Then click `Debug` on the menu bar and select `Start Without Debugging`.

To run tests within the `InfixExpressionCalculator.Tests` project, install an NUnit test runner (e.g. Resharper), right-click on the `InfixExpressionCalculator.Tests` project, and select `Run Unit Tests`.

# Observations

- Supported operators include `*`, `/`, `+`, and `-`. `(` and `)` parentheses are also supported.

  - Note that the `-` operator cannot be used to negate a number as a different operator would be required to implement this functionality.
  
- Since a traditional calculator does not allow spaces, the program will remove spaces before processing an infix expression. This means that numbers separated by spaces will be concatenated together. For example, `20 15` would be parsed as `2015`.

- For simplicity, adjacent numbers in parentheses are concatenated rather than multiplied. For example, `(5)(6)` would be parsed as `56` rather than `5*6`.

# MIT License

Copyright (c) 2015 Jordan Brown

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.