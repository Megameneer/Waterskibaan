using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterSkiBaan.Sporters;
using WaterSkiBaan.Wachtrijen;

namespace WaterSkiBaanTest
{
    [TestClass]
    public class WachtrijStartenTest
    {
        [TestMethod]
        public void AddToQueue()
        {
            Wakeboarder wakeboarder = new Wakeboarder();
            WachtrijStarten wachtrijStarten = new WachtrijStarten();
            wachtrijStarten.VoegSporterToeAanRij(wakeboarder);
        }
    }
}