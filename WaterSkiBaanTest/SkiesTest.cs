using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaterSkiBaan.SportUitrusting;

namespace WaterSkiBaanTest
{
    [TestClass]
    public class SkiesTest
    {
        [TestMethod]
        public void SkiesTest_Construct()
        {
            Skies skies = new Skies(1);
        }

//        [TestMethod]
//        public void SkieOpslag_DuplicateId_MustGiveError()
//        {
//            Assert.ThrowsException<Exception>(() =>
//            {
//                Skies skies = new Skies(2);
//                Skies duplicateSkies = new Skies(2);
//            });
//        }
    }
}