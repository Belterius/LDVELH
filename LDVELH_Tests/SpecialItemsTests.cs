using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WindowsForm;

namespace LDVELH_Tests
{
    [TestClass]
    public class SpecialItemsTests
    {
        [TestMethod]
        public void SpecialItem_Add()
        {
            SpecialItem specialItem = new SpecialItemCombat("useless item", 1,0);
            SpecialItem specialItemSame = new SpecialItemCombat("useless item", 1, 0);
            Hero hero = new Hero("hero");

            hero.addSpecialItem(specialItem);

            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItem));
            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItemSame));

        }

        [TestMethod]
        public void SpecialItem_Remove()
        {
            SpecialItem specialItem = new SpecialItemCombat("useless item", 1, 0);
            Hero hero = new Hero("hero");
            hero.addSpecialItem(specialItem);

            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItem));

            SpecialItem specialItemRemoval = new SpecialItemCombat("useless item", 1, 0);
            hero.removeSpecialItem(specialItemRemoval);

            Assert.AreEqual(false, hero.getSpecialItems.Contains(specialItem));

        }
    }
}
