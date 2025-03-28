
namespace TemplateEngineTests
{
    using TemplateEngine;
    [TestClass]
    public class TemplateEngineTest
    {
        [TestMethod]
        [DataRow("Alok", "Kumar", "Panda")]
        public void TestMethod1(string theValue1, string theValue2, string theValue3)
        { 
            // Arrange
            TemplateEngine aTemplateEngine = new TemplateEngine();
            aTemplateEngine.SetTemplate("Hello {name} {middlename} {surname}");
            aTemplateEngine.SetVariable("name", theValue1);
            aTemplateEngine.SetVariable("middlename", theValue2);
            aTemplateEngine.SetVariable("surname", theValue3);

            // Act
            string aResult = aTemplateEngine.Evaluate();

            // Assert
            Assert.AreEqual("Hello Alok Kumar Panda", aResult);
        }
    }
}