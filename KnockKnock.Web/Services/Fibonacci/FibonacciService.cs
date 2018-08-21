using System;

namespace KnockKnock.Web.Services.Fibonacci
{
    public class FibonacciService : IFibonacciService
    {
        public long GetNthFibonacciNumber(long nthNumber)
        {
            var sqr5 = Math.Sqrt(5);
            var phi = (sqr5 + 1) / 2;
            var fib = (long)(Math.Pow(phi, nthNumber) / sqr5 + 0.5);

            return fib;
        }
    }
}