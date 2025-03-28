namespace PredictionEngineTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PredictionEngineInterface;
    using PredictionEngine;

    [TestClass]
    public class PredictionEngineTests
    {
        [TestMethod]
        [DataRow("hello", "hello")]
        [DataRow("hello how are you do", "do")]
        public void ShouldCallMonogramWhenPartiallyWordWritten(string thePhrase, string theLastWord)
        {
            var aMockAlgo = new Mock<ILanguageModelAlgo>();
            var aPredictionEngine = new PredictionEngine(aMockAlgo.Object);

            aPredictionEngine.Predict(thePhrase);

            aMockAlgo.Verify(x => x.PredictUsingMonogram(theLastWord), Times.Once);
        }

        [TestMethod]
        [DataRow("hello ", "hello ")]
        [DataRow("hello how are you ", "you ")]
        public void ShouldCallBigramWhenSpaceIsTyped(string thePhrase, string theLastWord)
        {
            var aMockAlgo = new Mock<ILanguageModelAlgo>();
            var aPredictionEngine = new PredictionEngine(aMockAlgo.Object);

            aPredictionEngine.Predict(thePhrase);

            aMockAlgo.Verify(x => x.PredictUsingBigram(theLastWord), Times.Once);
        }
    }
}