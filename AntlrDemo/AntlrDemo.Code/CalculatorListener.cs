using Parser;

namespace AntlrDemo.Code
{
    public class CalculatorListener : CalculatorBaseListener
    {
        public override void EnterExpression(CalculatorParser.ExpressionContext context)
        {
            base.EnterExpression(context);
        }

        public override void ExitExpression(CalculatorParser.ExpressionContext context)
        {
            base.ExitExpression(context);
        }
    }
}