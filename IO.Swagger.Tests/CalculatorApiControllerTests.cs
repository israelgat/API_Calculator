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
        // Test for addition operation
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
        // Test for subtraction operation
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
        // Test for multiplication operation
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
        // Test for division operation
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
        // Test for division by zero
        public void Calculate_DivisionByZero_ReturnsBadRequest()
        {
            var controller = new CalculatorApiController();
            var body = new CalculateBody { Num1 = 10, Num2 = 0 };
            string operation = "divide";

            var result = controller.Calculate(body, operation);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

       
    }
}