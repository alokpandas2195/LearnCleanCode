namespace PredictionEngineInterface;

public interface ILanguageModelAlgo {
    public string PredictUsingMonogram(string word);

    public string PredictUsingBigram(string word);
}
