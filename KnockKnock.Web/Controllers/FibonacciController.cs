using System;
using KnockKnock.Web.Services.Fibonacci;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Web.Controllers
{
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        /// <summary>
        /// Retrieves the nth value in the fibonacci sequnce
        /// </summary>
        /// <param name="n">The nth value to find in the fibonacci sequence.</param>
        /// <returns>A Valid Ok result if n is a valid long parameter. Returns bad request if it is not valid.</returns>
        [HttpGet]
        public IActionResult Get(long n)
        {
            try
            {
                var isValidInt = long.TryParse(n.ToString(), out n);
                if (!isValidInt) return BadRequest("Invalid parameter provided, must be a whole number!");

                long fibResult = _fibonacciService.GetNthFibonacciNumber(n);
                if (fibResult > 0)
                {
                    return Ok(fibResult);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
    }
}
