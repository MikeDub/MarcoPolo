using System;
using System.Linq;

namespace KnockKnock.Web.Services.ReverseWords
{
    public class ReverseWordService : IReverseWordService
    {

        /// <inheritdoc />
        public string ReverseAllWordsInSentence(string sentence)
        {
            var reversedArray = (sentence ?? "").Split(' ').Select(s => new String(s.Reverse().ToArray()));
            return string.Join(" ", reversedArray);
        }
    }
}