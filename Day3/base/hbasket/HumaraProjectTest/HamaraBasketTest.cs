namespace HumaraProjectTest
{
    using hamaraBasket;
    [TestClass]
    public class HamaraBasketTest
    {
        private AbstractLayer myAbstractLayer;
        [TestMethod]
        public void GenericProductSellByValueShouldReduceByOne()
        {
            int aSellIn = 20;
            var aItems = PrepareItems("Lux Soap 10g", aSellIn, 20);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(aSellIn - 1, aItems[0].SellIn);
        }

        [TestMethod]
        public void GenericProductQualityValueShouldNeverReduceToNegativeValue()
        {
            int aQuality = 0;
            var aItems = PrepareItems("Lux Soap 10g", 10, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(aQuality, aItems[0].Quality); // If it is zero will not reduce further
        }

        [TestMethod]
        public void GenericProductQualityValueShouldReduceByOne()
        {
            int aQuality = 20;
            var aItems = PrepareItems("Lux Soap 10g", 10, aQuality);
            UpdateRequirementRules(aItems);
            
            Assert.AreEqual(aQuality - 1, aItems[0].Quality);
        }

        [TestMethod]
        [DataRow(20)]
        [DataRow(49)]
        public void IndianWineQualityValueShouldIncreaseTheOlderItGetsButNotMoreThan50(int theQuality)
        {
            var aItems = PrepareItems("Indian Wine", 10, theQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(theQuality + 1, aItems[0].Quality);
        }

        [TestMethod]
        [DataRow(20, 50)]
        [DataRow(49, 55)]
        public void ForestHoneyQualityValueShouldNotReduceNorHasToBeSold(int theQuality, int theSellIn)
        {
            var aItems = PrepareItems("Forest Honey", theSellIn, theQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(theQuality, aItems[0].Quality);
            Assert.AreEqual(theSellIn, aItems[0].SellIn);
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(9)]
        [DataRow(8)]
        [DataRow(7)]
        [DataRow(6)]
        public void MovieTicketQualityValueShouldIncreaseBy2When10DayOrLessOlderButMoreThan5(int theSellIn)
        {
            var aQuality = 48;
            var aItems = PrepareItems("Movie Tickets", theSellIn, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(aQuality + 2, aItems[0].Quality);
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(9)]
        [DataRow(8)]
        [DataRow(7)]
        [DataRow(6)]
        public void MovieTicketQualityValueShouldIncreaseBy2When10DayOrLessOlderButMoreThan5_Max50(int theSellIn)
        {
            var aQuality = 49;
            var aItems = PrepareItems("Movie Tickets", theSellIn, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(50, aItems[0].Quality);
        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(4)]
        [DataRow(3)]
        [DataRow(2)]
        [DataRow(1)]
        public void MovieTicketQualityValueShouldIncreaseBy3When5DayOrLessOlderButMoreThan(int theSellIn)
        {
            var aQuality = 20;
            var aItems = PrepareItems("Movie Tickets", theSellIn, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(aQuality + 3, aItems[0].Quality);
        }
         
        [TestMethod]
        public void MovieTicketQualityValueDropsTo0()
        {
            var aQuality = 20;
            var aItems = PrepareItems("Movie Tickets", 0, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(0, aItems[0].Quality);
        }

        [TestMethod]
        [DataRow("Movie Tickets")]
        [DataRow("Forest Honey")]
        [DataRow("Indian Wine")]
        [DataRow("Lux Soap 10g")]
        public void QualityValueShouldNotIncreaseMoreThan50ForAnyItem(string theItemName)
        {
            var aQuality = 50;
            var aSellIn = 25;
            var aItems = PrepareItems("Movie Tickets", aSellIn, aQuality);
            UpdateRequirementRules(aItems);

            Assert.AreEqual(aQuality, aItems[0].Quality);
        }

        private IList<Item> PrepareItems(string aName, int aSellIn, int aQuality)
        {
            return new List<Item> { new Item { Name = aName, SellIn = aSellIn, Quality = aQuality } };
        }

        private void UpdateRequirementRules(IList<Item> theItems)
        {
            myAbstractLayer = new AbstractLayer(new HamaraBasket(theItems));
            myAbstractLayer.UpdateQuality();
        }
    }
}