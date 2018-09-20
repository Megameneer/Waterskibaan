using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterSkiBaan.Kabelbaan;

namespace WaterSkiBaanTest
{
    [TestClass]
    public class LijnenInGebruikTest
    {
        [TestMethod]
        public void LijnenInGebruik_Construct()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
        }

        [TestMethod]
        public void LijnenInGebruik_NeemLijnInGebruik()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
            Lijn lijn = new Lijn(3);
            lijnenInGebruik.NeemLijnInGebruik(lijn);
            Assert.AreEqual(lijn, lijnenInGebruik.Lijnen.First.Value);
        }
        
        [TestMethod]
        public void LijnenInGebruik_NeemLijnInGebruik_LineTakenInUseIsAtFirstPointOfStack()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
            Lijn lijn = new Lijn(3);
            lijnenInGebruik.NeemLijnInGebruik(lijn);
            Lijn lijn2 = new Lijn(4);
            lijnenInGebruik.NeemLijnInGebruik(lijn2);
            Assert.AreEqual(lijn2, lijnenInGebruik.Lijnen.First.Value);
        }

        [TestMethod]
        public void LijnenInGebruik_NeemLijnInGebruik_LineTakenInUseIsAtPosition0()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
            Lijn lijn = new Lijn(3);
            lijnenInGebruik.NeemLijnInGebruik(lijn);
            Assert.AreEqual(0, lijnenInGebruik.Lijnen.First.Value.Positie);
        }

        [TestMethod]
        public void LijnenInGebruik_StelLijnenBuitenGebruik_LineIsRemovedFromLinesInUse()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
            Lijn lijn = new Lijn(3);
            lijnenInGebruik.NeemLijnInGebruik(lijn);
            lijnenInGebruik.StelLijnBuitenGebruik(lijn);
            Assert.AreEqual(0, lijnenInGebruik.Lijnen.Count);
        }
        
        [TestMethod]
        public void LijnenInGebruik_StelLijnenBuitenGebruik_LineIsAddedToLinesOutOfUse()
        {
            LijnenInGebruik lijnenInGebruik = new LijnenInGebruik();
            Lijn lijn = new Lijn(3);
            lijnenInGebruik.NeemLijnInGebruik(lijn);
            lijnenInGebruik.StelLijnBuitenGebruik(lijn);
            Assert.AreEqual(lijn, lijnenInGebruik.LijnenUitgerangeerd.Dequeue());
        }
    }
}