using AntlrDemo.Code;
using FluentAssertions;
using Xunit;

namespace AntlrDemo.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void StringCalculator_WhenCalledWithAddition_ShouldReturnCorrectResult()
        {
            const string input = "2 + 3";
            const string expectedResult = "5";

            new StringCalculator()
                .Evaluate(input)
                .Should().Be(expectedResult);
        }

        [Fact]
        public void StringCalculator_WhenCalledWithSubtraction_ShouldReturnCorrectResult()
        {
            const string input = "2 - 3";
            const string expectedResult = "-1";

            new StringCalculator()
                .Evaluate(input)
                .Should().Be(expectedResult);
        }

        [Fact]
        public void StringCalculator_WhenCalledWithMultiplication_ShouldReturnCorrectResult()
        {
            const string input = "2 * 3";
            const string expectedResult = "6";

            new StringCalculator()
                .Evaluate(input)
                .Should().Be(expectedResult);
        }

        [Fact]
        public void StringCalculator_WhenCalledWithDivision_ShouldReturnCorrectResult()
        {
            const string input = "6 / 3";
            const string expectedResult = "2";

            new StringCalculator()
                .Evaluate(input)
                .Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4", "11")]
        [InlineData("1 + 2 * (3 + 4)", "15")]
        [InlineData("7--3", "10")]
        [InlineData("-6*-6", "36")]
        [InlineData("77", "77")]
        public void StringCalculator_WhenCalledWithComplexExpression_ShouldReturnCorrectResult(string input, string expectedResult)
        {
            new StringCalculator()
                .Evaluate(input)
                .Should().Be(expectedResult);
        }
    }
}