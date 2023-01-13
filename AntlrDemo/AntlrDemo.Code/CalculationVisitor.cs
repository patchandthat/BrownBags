using Parser;

namespace AntlrDemo.Code
{
    public class CalculationVisitor : CalculatorBaseVisitor<int>
    {
        public override int VisitBody(CalculatorParser.BodyContext context)
        {
            return context.expression().Accept(this);
        }

        public override int VisitExpression(CalculatorParser.ExpressionContext context)
        {
            string first = context.NUMBER(0).GetText();
            string second = context.NUMBER(1).GetText();

            var op = context.op.Type;
            switch (op)
            {
                case CalculatorLexer.ADD:
                    return int.Parse(first) + int.Parse(second);
                case CalculatorLexer.SUBTRACT:
                    return int.Parse(first) - int.Parse(second);
                case CalculatorLexer.MULTIPLY:
                    return int.Parse(first) * int.Parse(second);
                case CalculatorLexer.DIVIDE:
                    return int.Parse(first) / int.Parse(second);
            }

            return 0;
        }
    }
}