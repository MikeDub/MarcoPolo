using KnockKnock.Web.Controllers;
using KnockKnock.Web.Services.ReverseWords;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace KnockKnock.Tests
{
    public class ReverseWordsTests
    {
        [Test]
        public void GetResult_OnReverseWordsController_ReturnsValidValues()
        {
            //Arrange
            IReverseWordService reverseWordService = new ReverseWordService();
            ReverseWordsController reverseWordsController = new ReverseWordsController(reverseWordService);
            string specialSentence = "urna, gravida. Nunc eget fermentum velit.; bla -lol";
            string specialExpected = ",anru .adivarg cnuN tege mutnemref ;.tilev alb lol-";
            string longSentence =
                "reverse this massively long never ever ever ever ending sentence which can go on forever and ever";
            string longExpected = "esrever siht ylevissam gnol reven reve reve reve gnidne ecnetnes hcihw nac og no reverof dna reve";

            //Act
            var nullResult = reverseWordsController.Get(null) as OkObjectResult;
            var spaceResult = reverseWordsController.Get(" ") as OkObjectResult;
            var leftSpaceResult = reverseWordsController.Get(" yoyo") as OkObjectResult;
            var rightSpaceResult = reverseWordsController.Get("lolli ") as OkObjectResult;
            var leftAndRightSpacedResult = reverseWordsController.Get(" red car ") as OkObjectResult;
            var multiSpacesResult = reverseWordsController.Get("    spaced out  ") as OkObjectResult; //4 spaces on left, 2 on right.
            var basicResult = reverseWordsController.Get("one") as OkObjectResult;
            var specialResult = reverseWordsController.Get(specialSentence) as OkObjectResult;
            var longResult = reverseWordsController.Get(longSentence) as OkObjectResult;

            //Assert
            Assert.That(nullResult?.Value, Is.EqualTo("")); //According to the test portal, we need to return an empty string
            Assert.That(spaceResult?.Value, Is.EqualTo(" ")); //No Transformation
            Assert.That(leftSpaceResult?.Value, Is.Not.Null.And.EqualTo(" oyoy"));
            Assert.That(rightSpaceResult?.Value, Is.Not.Null.And.EqualTo("illol "));
            Assert.That(leftAndRightSpacedResult?.Value, Is.Not.Null.And.EqualTo(" der rac "));
            Assert.That(multiSpacesResult?.Value, Is.Not.Null.And.EqualTo("    decaps tuo  "));
            Assert.That(basicResult?.Value, Is.Not.Null.And.EqualTo("eno"));
            Assert.That(specialResult?.Value, Is.Not.Null.And.EqualTo(specialExpected));            
            Assert.That(longResult?.Value, Is.Not.Null.And.EqualTo(longExpected));
        }

        [Test]
        public void ReverseAllWordsInSentence_OnReverseWordsService_ReturnsValidValues()
        {
            //Arrange
            IReverseWordService reverseService = new ReverseWordService();
            string nullSentence = null;
            string singleWordSentence = "one";
            string singleWordExpected = "eno";
            string doubleUpSentence = "this is great this not great this";
            string doubleUpExpected = "siht si taerg siht ton taerg siht";
            string wordInWordSentence = "reverse ever reverse, target get goto to forever land and got";
            string wordInWordExpected = "esrever reve ,esrever tegrat teg otog ot reverof dnal dna tog";
            string specialCharSentence = "urna, gravida. Nunc eget fermentum velit.; bla -lol";
            string specialCharExpected = ",anru .adivarg cnuN tege mutnemref ;.tilev alb lol-";
            string superSpaceSentence = "     space this   and  this  ";
            string superSpaceExpected = "     ecaps siht   dna  siht  ";
            string justDottinAround = ". .. ..!";
            string justDottinAroundExpected = ". .. !..";

            //Act
            var nullWordResult = reverseService.ReverseAllWordsInSentence(nullSentence);
            var singleWordResult = reverseService.ReverseAllWordsInSentence(singleWordSentence);
            var doubleUpResult = reverseService.ReverseAllWordsInSentence(doubleUpSentence);
            var wordInWordResult = reverseService.ReverseAllWordsInSentence(wordInWordSentence);
            var specialCharResult = reverseService.ReverseAllWordsInSentence(specialCharSentence);
            var superSpaceResult = reverseService.ReverseAllWordsInSentence(superSpaceSentence);
            var justDottinAroundResult = reverseService.ReverseAllWordsInSentence(justDottinAround);

            //Assert
            Assert.That(nullWordResult, Is.EqualTo(""));
            Assert.That(singleWordResult, Is.EqualTo(singleWordExpected));
            Assert.That(doubleUpResult, Is.EqualTo(doubleUpExpected));
            Assert.That(wordInWordResult, Is.EqualTo(wordInWordExpected));
            Assert.That(specialCharResult, Is.EqualTo(specialCharExpected));
            Assert.That(superSpaceResult, Is.EqualTo(superSpaceExpected));
            Assert.That(justDottinAroundResult, Is.EqualTo(justDottinAroundExpected));
        }
    }
}
