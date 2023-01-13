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
            if (context.op == null)
            {
                string num = context.NUMBER().GetText();
                return int.Parse(num);
            }
            
            int first = context.expression(0).Accept(this);
            int second = context.expression(1).Accept(this);

            var op = context.op.Type;
            var function = operations[op];
            return function(first, second);
        }
    }
}