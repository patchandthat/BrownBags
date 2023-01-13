using Parser;

namespace AntlrDemo.Code
{
    public class CalculationVisitor : CalculatorBaseVisitor<int>
    {
        private Dictionary<int, Func<int, int, int>> operations = new()
        {
            { CalculatorLexer.ADD, (first, second) => first + second },
            { CalculatorLexer.SUBTRACT, (first, second) => first - second },
            { CalculatorLexer.MULTIPLY, (first, second) => first * second },
            { CalculatorLexer.DIVIDE, (first, second) => first / second },
        };

        public override int VisitBody(CalculatorParser.BodyContext context)
        {
            return context.expression().Accept(this);
        }

        public override int VisitExpression(CalculatorParser.ExpressionContext context)
        {
            string first = context.NUMBER(0).GetText();
            string second = context.NUMBER(1).GetText();

            var op = context.op.Type;
            var function = operations[op];
            return function(int.Parse(first), int.Parse(second));
        }
    }
}