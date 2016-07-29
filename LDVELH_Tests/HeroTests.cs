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
            Capacity weaponMasteryCapacity = new Capacity(CapacityType.MaitriseDesArmes);
            Hero heroNoWeaponMastery = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Camouflage);

            heroWeaponMastery.addCapacity(weaponMasteryCapacity);
            heroNoWeaponMastery.addCapacity(hidingCapacity);

            Assert.AreEqual(true, (heroWeaponMastery.getWeaponMastery != WeaponTypes.None));
            Assert.AreEqual(true, (heroNoWeaponMastery.getWeaponMastery == WeaponTypes.None));
        }

        [TestMethod]
        public void HeroPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Camouflage);

            Belterius.addCapacity(hidingCapacity);

            Assert.AreEqual(true, Belterius.possesCapacity(CapacityType.Camouflage));
        }

        [TestMethod]
        public void HeroDoesntPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Camouflage);

            Belterius.addCapacity(hidingCapacity);

            Assert.AreEqual(false, Belterius.possesCapacity(CapacityType.PuissancePsychique));
        }

        [TestMethod]
        public void HeroStrenghtDifference()
        {
            Hero Belterius = new Hero("Belterius");
            Ennemy evilHuman = new Ennemy("Common Human", 10, 10, EnnemyTypes.Human);
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
            Belterius.addCapacity(CapacityType.PuissancePsychique);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + Capacity.phychicPowerStrenght - LDVELH_WPF.Hero.unharmedCombatDebuff) - evilHuman.getBaseAgility();

            Assert.AreEqual(expectedStrenghtDifference, Belterius.findStrenghtDifference(evilHuman));

            //Weapon Mastery (with and without weapon) test
            Belterius.addCapacity(CapacityType.MaitriseDesArmes);
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
            Ennemy evilOrc = new Ennemy("Common Orc", 15, 10, EnnemyTypes.Orc);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).getAgilityBonus + ((SpecialItemCombat)ring).getAgilityBonus + Capacity.weaponMasteryStrenght) - evilOrc.getBaseAgility();

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



    }
}
