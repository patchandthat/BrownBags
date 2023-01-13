using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
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

            // Will go bang if the input syntax is incorrect
            IParseTree expressionTree = parser.body();

            // Walk over the entire tree and invoke listener methods on entering and leaving each rule
            // Returns void, your listener should build up state and have a property to expose the info
            // you are interested in
            // var listener = new CalculatorListener();
            // ParseTreeWalker.Default.Walk(listener, expressionTree);

            // Visit the tree with a custom visitor, returning a result
            // you are responsible for walking through the sub-tree yourself
            var visitor = new CalculationVisitor();
            var result = expressionTree.Accept(visitor);

            return result.ToString();
        }
    }
}