using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WindowsForm;

namespace LDVELH_Tests
{
    [TestClass]
    public class ItemTests
    {

        [TestMethod]
        public void Item_Compare_GenericConsummable()
        {
            Consummable consummableActual;
            Consummable consummableExpected;

            consummableActual = CreateLoot.CreateConsummable.minorHealthPotion();
            consummableExpected = new Consummable("minor health potion", 4, 3);

            Assert.AreEqual(true, consummableActual.Equals(consummableExpected));
        }

        [TestMethod]
        public void Item_Create_MinorHealthPotion()
        {
            Consummable minorHealthPotionActual;
            Consummable minorHealthPotionExpected;

            minorHealthPotionActual = CreateLoot.CreateConsummable.minorHealthPotion();
            minorHealthPotionExpected = new Consummable("minor health potion", 4, 3);

            Assert.AreEqual(minorHealthPotionExpected, minorHealthPotionActual);
        }

    }
}
