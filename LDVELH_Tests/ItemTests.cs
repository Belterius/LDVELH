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
            Consumable consummableActual = CreateLoot.CreateConsumable.MinorHealthPotion();
            Consumable consummableExpected = new Consumable("minor health potion", 4, 3);

            Assert.AreEqual(true, consummableActual.Equals(consummableExpected));
        }

        [TestMethod]
        public void Item_Create_MinorHealthPotion()
        {
            Consumable minorHealthPotionActual = CreateLoot.CreateConsumable.MinorHealthPotion();
            Consumable minorHealthPotionExpected = new Consumable("minor health potion", 4, 3);

            Assert.AreEqual(minorHealthPotionExpected, minorHealthPotionActual);
        }

    }
}
