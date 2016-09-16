using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class HeroTests
    {
        [TestMethod]
        public void HeroWeaponMastery()
        {
            Hero heroWeaponMastery = new Hero("Belterius");
            Capacity weaponMasteryCapacity = new Capacity(CapacityType.WeaponMastery);
            Hero heroNoWeaponMastery = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);

            heroWeaponMastery.AddCapacity(weaponMasteryCapacity);
            heroNoWeaponMastery.AddCapacity(hidingCapacity);

            Assert.AreEqual(true, (heroWeaponMastery.WeaponMastery != WeaponTypes.None));
            Assert.AreEqual(true, (heroNoWeaponMastery.WeaponMastery == WeaponTypes.None));
        }

        [TestMethod]
        public void HeroPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);

            Belterius.AddCapacity(hidingCapacity);

            Assert.AreEqual(true, Belterius.PossesCapacity(CapacityType.Hiding));
        }

        [TestMethod]
        public void HeroDoesntPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);

            Belterius.AddCapacity(hidingCapacity);

            Assert.AreEqual(false, Belterius.PossesCapacity(CapacityType.PsychicPower));
        }

        [TestMethod]
        public void HeroStrenghtDifference()
        {
            Hero Belterius = new Hero("Belterius");
            Enemy evilHuman = new Enemy("Common Human", 10, 10, EnemyTypes.Human);
            int heroBaseAgility = Belterius.BaseAgility;

            //Base test
            int expectedStrenghtDifference = heroBaseAgility - LDVELH_WPF.Hero.UnharmedCombatDebuff - evilHuman.BaseAgility;
            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilHuman));

            //Item test
            SpecialItem shield = new SpecialItemCombat("iron shield", 4, 0);
            Belterius.AddLoot(shield);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus - LDVELH_WPF.Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilHuman));

            //PsychicPower test
            Belterius.AddCapacity(CapacityType.PsychicPower);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght - LDVELH_WPF.Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilHuman));

            //Weapon Mastery (with and without weapon) test
            Belterius.AddCapacity(CapacityType.WeaponMastery);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght - LDVELH_WPF.Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility; //No weapon related to the Weapon mastery so no bonus

            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilHuman));

            Weapon wmWeapon = new Weapon("perfect weapon", Belterius.WeaponMastery);
            Belterius.WeaponHolder.Add(wmWeapon);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght + Capacity.WeaponMasteryStrenght) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilHuman));

            //Multiples Items, Weapon Mastery, and psychic immune
            //WARNING TEST WILL FAIL IF ORC IS NOT IMMUN TO PSYCHIC ANYMORE, can check in Ennemy isWeakToPsychic
            SpecialItem ring = new SpecialItemCombat("magic ring", 6, 0);
            Belterius.AddLoot(ring);
            Enemy evilOrc = new Enemy("Common Orc", 15, 10, EnemyTypes.Orc);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + ((SpecialItemCombat)ring).AgilityBonus + Capacity.WeaponMasteryStrenght) - evilOrc.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.FindStrenghtDifference(evilOrc));

        }

        [TestMethod]
        public void HeroFight()
        {
            Hero hero = new Hero("hero");
            Enemy beast = new Enemy("beast", 22, 20, EnemyTypes.Beast);
            bool battleOver = false;
            try
            {
                do
                {
                    battleOver = hero.Fight(beast);
                } while (!battleOver);
                Assert.AreEqual(0, beast.ActualHitPoint); //The beast is dead
            }
            catch (YouAreDeadException)
            {
                Assert.AreEqual(0, hero.ActualHitPoint);//The hero is dead
            }
        }


        [TestMethod]
        public void Hero_RemoveAllItems_Tests()
        {
            Hero myHero = new Hero("Belterius");
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            Consummable consummable2 = new Consummable("Random Consumable", 12, 1);
            Consummable consummable4 = new Consummable("Random Consumable", 12, 1);//Allow to check if the override Equal works on Contains()
            Consummable consummable3 = new Consummable("Random Consumable FALSE", 12, 1);
            myHero.AddLoot(consummable);
            myHero.AddLoot(consummable2);
            myHero.AddLoot(consummable4);
            myHero.AddLoot(consummable3);

            myHero.RemoveBackPack();

            Assert.AreEqual(0, myHero.BackPack.GetItems.Count);

        }

        [TestMethod]
        public void Hero_RemoveAllWeapons_Tests()
        {

            Hero myHero = new Hero("Belterius");
            Weapon advancedSword = new Weapon("advanced sword", WeaponTypes.Sword);
            Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);
            myHero.AddLoot(advancedSword);
            myHero.AddLoot(basicSpear);

            myHero.RemoveWeaponHolder();

            Assert.AreEqual(0, myHero.WeaponHolder.GetWeapons.Count);

        }

    }
}
