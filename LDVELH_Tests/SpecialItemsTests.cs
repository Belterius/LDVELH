using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class SpecialItemsTests
    {
        [TestMethod]
        public void SpecialItem_Add()
        {
            SpecialItem specialItem = new SpecialItemCombat("useless item", 1, 0);
            SpecialItem specialItemSame = new SpecialItemCombat("useless item", 1, 0);
            Hero hero = new Hero("hero");

            hero.addLoot(specialItem);

            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItem));
            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItemSame));

        }

        [TestMethod]
        public void SpecialItem_Remove()
        {
            SpecialItem specialItem = new SpecialItemCombat("useless item", 1, 0);
            Hero hero = new Hero("hero");
            hero.addLoot(specialItem);

            Assert.AreEqual(true, hero.getSpecialItems.Contains(specialItem));

            SpecialItem specialItemRemoval = new SpecialItemCombat("useless item", 1, 0);
            hero.removeLoot(specialItemRemoval);

            Assert.AreEqual(false, hero.getSpecialItems.Contains(specialItem));

        }

        [TestMethod]
        public void SpecialItem_AddSpecialItemAlways()
        {
            int bonusAgi = 5;
            int bonusHP = 3;
            SpecialItem specialItem = new SpecialItemAlways("amazing item", bonusAgi, bonusHP);
            Hero hero = new Hero("hero");
            int heroAgility = hero.getBaseAgility();
            int heroHP = hero.getMaxHitPoint();

            hero.addLoot(specialItem);

            Assert.AreEqual(heroAgility + bonusAgi, hero.getBaseAgility());
            Assert.AreEqual(heroHP + bonusHP, hero.getMaxHitPoint());
        }
        [TestMethod]
        public void SpecialItem_RemoveSpecialItemAlways()
        {
            int bonusAgi = 5;
            int bonusHP = 3;
            SpecialItem specialItem = new SpecialItemAlways("amazing item", bonusAgi, bonusHP);
            Hero hero = new Hero("hero");
            int heroAgility = hero.getBaseAgility();
            int heroHP = hero.getMaxHitPoint();
            hero.addLoot(specialItem);

            hero.removeLoot(specialItem);

            Assert.AreEqual(heroAgility, hero.getBaseAgility());
            Assert.AreEqual(heroHP, hero.getMaxHitPoint());
        }
    }
}
