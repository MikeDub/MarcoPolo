using KnockKnock.Web.Controllers;
using KnockKnock.Web.Services.TriangleType;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace KnockKnock.Tests
{
    public class TriangleTypeTests
    {
        [Test]
        public void GetResult_OnTriangleTypeController_ReturnsValidValues()
        {
            //Arrange
            ITriangleTypeService triangleTypeService = new TriangleTypeService();
            TriangleTypeController triangleTypeController = new TriangleTypeController(triangleTypeService);

            //Act
            var errorResult = triangleTypeController.Get(1, 1, 1) as OkObjectResult;
            var negResult = triangleTypeController.Get(-2, -3, -4) as OkObjectResult;
            var allEvenResult = triangleTypeController.Get(3, 3, 3) as OkObjectResult;
            var twoEvenResult = triangleTypeController.Get(3, 2, 3) as OkObjectResult;
            var noEvenResult = triangleTypeController.Get(4, 3, 2) as OkObjectResult;

            //Assert
            Assert.That(errorResult?.Value, Is.EqualTo("Error"));
            Assert.That(negResult?.Value, Is.EqualTo("Error"));
            Assert.That(allEvenResult?.Value, Is.EqualTo("Equilateral"));
            Assert.That(twoEvenResult?.Value, Is.EqualTo("Isosceles"));
            Assert.That(noEvenResult?.Value, Is.EqualTo("Scalene"));
        }

        [Test]
        public void CalculateTriangleType_OnTriangleTypeService_ReturnsExpectedValues()
        {
            //Arrange
            ITriangleTypeService triangleTypeService = new TriangleTypeService();

            //Act
            var errorResult = triangleTypeService.CalculateTriangleType(1, 1, 1);
            var negativeResult = triangleTypeService.CalculateTriangleType(-2, -4, -6);
            var allEqualResult = triangleTypeService.CalculateTriangleType(3, 3, 3);
            var abEqualResult = triangleTypeService.CalculateTriangleType(4, 4, 2);
            var acEqualResult = triangleTypeService.CalculateTriangleType(4, 2, 4);
            var bcEqualResult = triangleTypeService.CalculateTriangleType(2, 4, 4);
            var allDifferentResult = triangleTypeService.CalculateTriangleType(5, 4, 3);

            //Assert
            Assert.That(errorResult, Is.EqualTo("Error"));
            Assert.That(negativeResult, Is.EqualTo("Error"));
            Assert.That(allEqualResult, Is.EqualTo("Equilateral"));
            Assert.That(abEqualResult, Is.EqualTo("Isosceles"));
            Assert.That(acEqualResult, Is.EqualTo("Isosceles"));
            Assert.That(bcEqualResult, Is.EqualTo("Isosceles"));
            Assert.That(allDifferentResult, Is.EqualTo("Scalene"));
        }
    }
}
