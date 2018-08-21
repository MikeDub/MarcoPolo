using System;
using KnockKnock.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace KnockKnock.Tests
{
    public class TokenTests
    {
        [Test]
        public void GetResult_OnTokenController_ReturnsValidValue()
        {
            //Arrange
            TokenController tokenController = new TokenController();

            //Act
            var normalResult = tokenController.Get() as OkObjectResult;

            //Assert
            Assert.That(normalResult?.Value, Is.EqualTo(new Guid("7004cd8e-58f2-43d3-902e-0eebf7385dae")));            
        }
    }
}
