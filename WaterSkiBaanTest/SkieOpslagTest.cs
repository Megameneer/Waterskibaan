using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterSkiBaan.SportUitrusting;

namespace WaterSkiBaanTest
{
    [TestClass]
    public class SkieOpslagTest
    {
        [TestMethod]
        public void SkieOpslag_Construct()
        {
            SkieOpslag skieOpslag = new SkieOpslag();
        }

        [TestMethod]
        public void SkieOpslag_Afgeven()
        {
            SkieOpslag skieOpslag = new SkieOpslag();
            Skies skies = new Skies(1);
            skieOpslag.Afgeven(skies);
        }

        [TestMethod]
        public void SkieOpslag_PakSkies()
        {
            SkieOpslag skieOpslag = new SkieOpslag();
            Skies skies = new Skies(1);
            skieOpslag.Afgeven(skies);
            Assert.AreSame(skies, skieOpslag.PakSkies());
        }
    }
}