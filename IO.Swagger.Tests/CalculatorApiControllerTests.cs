using Xunit;
using IO.Swagger.Controllers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace IO.Swagger.Tests
{
    public class CalculatorApiControllerTests
    {
        [Fact]
        public void Calculate_Addition_ReturnsCorrectResult()
        {
            // Arrange
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 5 };
            string operation = "add";

            // Act
            var result = controller.Calculate(body, operation) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            var response = result.Value as InlineResponse200;
            response.Result.Should().Be(15);
        }

        [Fact]
        public void Calculate_Subtraction_ReturnsCorrectResult()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 5 };
            string operation = "subtract";

            var result = controller.Calculate(body, operation) as OkObjectResult;

            var response = result.Value as InlineResponse200;
            response.Result.Should().Be(5);
        }

        [Fact]
        public void Calculate_Multiplication_ReturnsCorrectResult()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 5 };
            string operation = "multiply";

            var result = controller.Calculate(body, operation) as OkObjectResult;

            var response = result.Value as InlineResponse200;
            response.Result.Should().Be(50);
        }

        [Fact]
        public void Calculate_Division_ReturnsCorrectResult()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 5 };
            string operation = "divide";

            var result = controller.Calculate(body, operation) as OkObjectResult;

            var response = result.Value as InlineResponse200;
            response.Result.Should().Be(2);
        }

        [Fact]
        public void Calculate_DivisionByZero_ReturnsBadRequest()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 0 };
            string operation = "divide";

            var result = controller.Calculate(body, operation);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Calculate_InvalidOperation_ReturnsBadRequest()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 5 };
            string operation = "modulus";

            var result = controller.Calculate(body, operation);

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}