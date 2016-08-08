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

            heroWeaponMastery.addCapacity(weaponMasteryCapacity);
            heroNoWeaponMastery.addCapacity(hidingCapacity);

            Assert.AreEqual(true, (heroWeaponMastery.getWeaponMastery != WeaponTypes.None));
            Assert.AreEqual(true, (heroNoWeaponMastery.getWeaponMastery == WeaponTypes.None));
        }

        [TestMethod]
        public void HeroPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);

            Belterius.addCapacity(hidingCapacity);

            Assert.AreEqual(true, Belterius.possesCapacity(CapacityType.Hiding));
        }

        [TestMethod]
        public void HeroDoesntPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);

            Belterius.addCapacity(hidingCapacity);

            Assert.AreEqual(false, Belterius.possesCapacity(CapacityType.PsychicPower));
        }

        [TestMethod]
        public void HeroStrenghtDifference()
        {
            Hero Belterius = new Hero("Belterius");
            Enemy evilHuman = new Enemy("Common Human", 10, 10, EnnemyTypes.Human);
            int heroBaseAgility = Belterius.getBaseAgility();

            //Base test
            int expectedStrenghtDifference = heroBaseAgility - LDVELH_WPF.Hero.unharmedCombatDebuff - evilHuman.getBaseAgility();
            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Item test
            SpecialItem shield = new SpecialItemCombat("iron shield", 4, 0);
            Belterius.addLoot(shield);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus - LDVELH_WPF.Hero.unharmedCombatDebuff) - evilHuman.getBaseAgility();

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //PsychicPower test
            Belterius.addCapacity(CapacityType.PsychicPower);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + Capacity.phychicPowerStrenght - LDVELH_WPF.Hero.unharmedCombatDebuff) - evilHuman.getBaseAgility();

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Weapon Mastery (with and without weapon) test
            Belterius.addCapacity(CapacityType.WeaponMastery);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + Capacity.phychicPowerStrenght - LDVELH_WPF.Hero.unharmedCombatDebuff) - evilHuman.getBaseAgility(); //No weapon related to the Weapon mastery so no bonus

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            Weapon wmWeapon = new Weapon("perfect weapon", Belterius.getWeaponMastery);
            Belterius.weaponHolder.Add(wmWeapon);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + Capacity.phychicPowerStrenght + Capacity.weaponMasteryStrenght) - evilHuman.getBaseAgility();

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Multiples Items, Weapon Mastery, and psychic immune
            //WARNING TEST WILL FAIL IF ORC IS NOT IMMUN TO PSYCHIC ANYMORE, can check in Ennemy isWeakToPsychic
            SpecialItem ring = new SpecialItemCombat("magic ring", 6, 0);
            Belterius.addLoot(ring);
            Enemy evilOrc = new Enemy("Common Orc", 15, 10, EnnemyTypes.Orc);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + ((SpecialItemCombat)ring).getAgilityBonus + Capacity.weaponMasteryStrenght) - evilOrc.getBaseAgility();

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilOrc));

        }

        [TestMethod]
        public void HeroFight()
        {
            Hero hero = new Hero("hero");
            Enemy beast = new Enemy("beast", 22, 20, EnnemyTypes.Beast);
            bool battleOver = false;
            try
            {
                do
                {
                    battleOver = hero.Fight(beast);
                } while (!battleOver);
                Assert.AreEqual(0, beast.getActualHitPoint()); //The beast is dead
            }
            catch (YouAreDeadException)
            {
                Assert.AreEqual(0, hero.getActualHitPoint());//The hero is dead
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
            myHero.addLoot(consummable);
            myHero.addLoot(consummable2);
            myHero.addLoot(consummable4);
            myHero.addLoot(consummable3);

            myHero.removeBackPack();

            Assert.AreEqual(0, myHero.backPack.getItems.Count);

        }

        [TestMethod]
        public void Hero_RemoveAllWeapons_Tests()
        {

            Hero myHero = new Hero("Belterius");
            Weapon advancedSword = new Weapon("advanced sword", WeaponTypes.Sword);
            Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);
            myHero.addLoot(advancedSword);
            myHero.addLoot(basicSpear);

            myHero.removeWeaponHolder();

            Assert.AreEqual(0, myHero.weaponHolder.getWeapons.Count);

        }

    }
}
