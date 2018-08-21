using KnockKnock.Web.Controllers;
using KnockKnock.Web.Services.Fibonacci;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace KnockKnock.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [Test]
        public void GetNthValue_OnFibonacciController_ReturnsValidValues()
        {
            //Arrange
            IFibonacciService fibService = new FibonacciService();
            FibonacciController fibController = new FibonacciController(fibService);

            //Act
            var outOfRangeResult = fibController.Get(100) as BadRequestResult;
            var basicResult = fibController.Get(1) as OkObjectResult;
            var smallResult = fibController.Get(8) as OkObjectResult;
            var largeResult = fibController.Get(70) as OkObjectResult;

            //Assert
            Assert.That(outOfRangeResult, Is.TypeOf(typeof(BadRequestResult)));
            Assert.That(basicResult?.Value, Is.Not.Null.And.EqualTo(1));
            Assert.That(smallResult?.Value, Is.Not.Null.And.EqualTo(21));
            Assert.That(largeResult?.Value, Is.Not.Null.And.EqualTo(190392490709135));
        }

        [Test]
        public void GetNthFibonacciNumber_OnFibonacciService_ReturnsValidFibonacci()
        {
            //Arrange
            IFibonacciService fibService = new FibonacciService();

            //Act
            var test1Result = fibService.GetNthFibonacciNumber(10);
            var test2Result = fibService.GetNthFibonacciNumber(50);

            //Assert
            Assert.That(test1Result, Is.EqualTo(55));
            Assert.That(test2Result, Is.EqualTo(12586269025));
        }


    }
}
