using Parser;

namespace AntlrDemo.Code
{
    public class CalculationVisitor : CalculatorBaseVisitor<int>
    {
        public override int VisitBody(CalculatorParser.BodyContext context)
        {
            return context.expression().Accept(this);
            return VisitExpression(context.expression());
        }

        public override int VisitExpression(CalculatorParser.ExpressionContext context)
        {
            return 5;
        }
    }
}