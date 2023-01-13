using Parser;

namespace AntlrDemo.Code
{
    public class CalculationVisitor : CalculatorBaseVisitor<int>
    {
        public override int VisitBody(CalculatorParser.BodyContext context)
        {
            return base.VisitBody(context);
        }

        public override int VisitExpression(CalculatorParser.ExpressionContext context)
        {
            return 5;
        }
    }
}