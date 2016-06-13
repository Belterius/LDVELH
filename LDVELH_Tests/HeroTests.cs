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
            Ennemy evilHuman = new Ennemy("Common Human", 10, 10, EnnemyTypes.Human);
            int heroBaseAgility = Belterius.getBaseAgility();

            //Base test
            int expectedStrenghtDifference = heroBaseAgility - 10;
            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Item test
            SpecialItem shield = new SpecialItemCombat("iron shield", 4, 0);
            Belterius.addLoot(shield);
            expectedStrenghtDifference = (heroBaseAgility + 4) - 10;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //PsychicPower test
            Belterius.addCapacity(CapacityType.PsychicPower);
            expectedStrenghtDifference = (heroBaseAgility + 4 + Capacity.phychicPowerStrenght) - 10;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Weapon Mastery (with and without weapon) test
            Belterius.addCapacity(CapacityType.WeaponMastery);
            expectedStrenghtDifference = (heroBaseAgility + 4 + Capacity.phychicPowerStrenght) - 10; //No weapon related to the Weapon mastery so no bonus

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            Weapon wmWeapon = new Weapon("perfect weapon", Belterius.getWeaponMastery);
            Belterius.weaponHolder.Add(wmWeapon);
            expectedStrenghtDifference = (heroBaseAgility + 4 + Capacity.phychicPowerStrenght + Capacity.weaponMasteryStrenght) - 10;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Multiples Items, Weapon Mastery, and psychic immune
            //WARNING TEST WILL FAIL IF ORC IS NOT IMMUN TO PSYCHIC ANYMORE, can check in Ennemy isWeakToPsychic
            SpecialItem ring = new SpecialItemCombat("magic ring", 6, 0);
            Belterius.addLoot(ring);
            Ennemy evilOrc = new Ennemy("Common Orc", 15, 10, EnnemyTypes.Orc);
            expectedStrenghtDifference = (heroBaseAgility + 4 + 6 + Capacity.weaponMasteryStrenght) - 15;

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilOrc));

        }

        [TestMethod]
        public void HeroFight()
        {
            Hero hero = new Hero("hero");
            Ennemy beast = new Ennemy("beast", 22, 20, EnnemyTypes.Beast);
            bool battleOver = false;
            try
            {
                do { 
                    battleOver = hero.Fight(beast);
                } while (!battleOver);
                Assert.AreEqual(0, beast.getActualHitPoint()); //The beast is dead
            }catch(YouAreDeadException){
                Assert.AreEqual(0, hero.getActualHitPoint());//The hero is dead
            }
        }

    }
}
