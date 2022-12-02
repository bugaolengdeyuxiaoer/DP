using System;
using System.Collections.Generic;
using Interpreter;

Console.Title = "Interpreter";
var expressions = new List<RomanExpression>
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
        new RomanOneExpression(),
};

var context = new RomanContext(5);
foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 = {context.Output}");

context = new RomanContext(32);
foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numerals to Roman numerals: 32 = {context.Output}");

context = new RomanContext(524);
foreach (var expression in expressions)
{
    expression.Interpret(context);
}

Console.WriteLine($"Translating Arabic numerals to Roman numerals: 524 = {context.Output}");