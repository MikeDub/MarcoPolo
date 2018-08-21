namespace KnockKnock.Web.Services.ReverseWords
{
    public interface IReverseWordService
    {
        /// <summary>
        /// Reverse the letters of all words in a sentence. This will NOT reverse the sentence.
        /// </summary>
        /// <param name="sentence">Sentence containing the words to reverse</param>
        /// <returns>Reversed result.</returns>
        string ReverseAllWordsInSentence(string sentence);
    }
}
