using KnockKnock.Web.Services.ReverseWords;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReverseWordsController : Controller
    {
        private readonly IReverseWordService _reverseWordService;

        public ReverseWordsController(IReverseWordService fibonacciService)
        {
            _reverseWordService = fibonacciService;
        }

        public IActionResult Get(string sentence)
        {
            string reversedResult = _reverseWordService.ReverseAllWordsInSentence(sentence);
            return Ok(reversedResult);
        }
        
    }
}
