using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class ItemTests
    {

        [TestMethod]
        public void Item_Compare_GenericConsummable()
        {
            Consumable consummableActual;
            Consumable consummableExpected;

            consummableActual = CreateLoot.CreateConsumable.minorHealthPotion();
            consummableExpected = new Consumable("minor health potion", 4, 3);

            Assert.AreEqual(true, consummableActual.Equals(consummableExpected));
        }

        [TestMethod]
        public void Item_Create_MinorHealthPotion()
        {
            Consumable minorHealthPotionActual;
            Consumable minorHealthPotionExpected;

            minorHealthPotionActual = CreateLoot.CreateConsumable.minorHealthPotion();
            minorHealthPotionExpected = new Consumable("minor health potion", 4, 3);

            Assert.AreEqual(minorHealthPotionExpected, minorHealthPotionActual);
        }

    }
}
