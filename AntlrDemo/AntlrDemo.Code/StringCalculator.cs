using Antlr4.Runtime;
using Parser;

namespace AntlrDemo.Code
{
    public class StringCalculator
    {
        public string Evaluate(string expression)
        {
            var charStream = CharStreams.fromString(expression);
            var lexer = new CalculatorLexer(charStream);
            var calculatorTokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(calculatorTokens);

            return "";
        }
    }
}