
using PredictionEngineInterface;

namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo myLanguageModelAlgo;

        public PredictionEngine(ILanguageModelAlgo theLanguageModelAlgo)
        {
            this.myLanguageModelAlgo = theLanguageModelAlgo;
        }

        public string Predict(string theWord)
        {
            if (string.IsNullOrWhiteSpace(theWord))
            {
                return string.Empty;
            }

            string[] words = theWord.Split(" ");
            if (theWord.EndsWith(" ") && words.Length >= 2)
            {
                theWord = words[words.Length - 2] + " ";
                return this.myLanguageModelAlgo.PredictUsingBigram(theWord);
            }
            else
            {
                return this.myLanguageModelAlgo.PredictUsingMonogram(words[words.Length - 1]);
            }            
        }
    }
}
