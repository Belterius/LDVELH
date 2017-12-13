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
            Hero heroNoWeaponMastery = new Hero("Belterius");

            heroWeaponMastery.AddCapacity(CapacityType.WeaponMastery);
            heroNoWeaponMastery.AddCapacity(CapacityType.Hiding);

            Assert.AreEqual(true, (heroWeaponMastery.WeaponMastery != WeaponTypes.None));
            Assert.AreEqual(true, (heroNoWeaponMastery.WeaponMastery == WeaponTypes.None));
        }

        [TestMethod]
        public void HeroPossesCapacity()
        {
            Hero belterius = new Hero("Belterius");

            belterius.AddCapacity(CapacityType.Hiding);

            Assert.AreEqual(true, belterius.PossesCapacity(CapacityType.Hiding));
        }

        [TestMethod]
        public void HeroDoesntPossesCapacity()
        {
            Hero belterius = new Hero("Belterius");

            belterius.AddCapacity(CapacityType.Hiding);

            Assert.AreEqual(false, belterius.PossesCapacity(CapacityType.PsychicPower));
        }
        [TestMethod]
        public void HeroRemovePossesedCapacity()
        {
            Hero belterius = new Hero("Belterius");
            belterius.AddCapacity(CapacityType.Hiding);
            Assert.AreEqual(true, belterius.PossesCapacity(CapacityType.Hiding));

            belterius.RemoveCapacity(CapacityType.Hiding);

            Assert.AreEqual(false, belterius.PossesCapacity(CapacityType.Hiding));
        }
        [TestMethod]
        public void HeroStrenghtDifference()
        {
            Hero belterius = new Hero("Belterius");
            Enemy evilHuman = new Enemy("Common Human", 10, 10, EnemyTypes.Human);
            int heroBaseAgility = belterius.BaseAgility;

            //Base test
            int expectedStrenghtDifference = heroBaseAgility - Hero.UnharmedCombatDebuff - evilHuman.BaseAgility;
            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilHuman));

            //Item test
            SpecialItem shield = new SpecialItemCombat("iron shield", 4, 0);
            belterius.AddLoot(shield);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus - Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilHuman));

            //PsychicPower test
            belterius.AddCapacity(CapacityType.PsychicPower);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght - Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilHuman));

            //Weapon Mastery (with and without weapon) test
            belterius.AddCapacity(CapacityType.WeaponMastery);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght - Hero.UnharmedCombatDebuff) - evilHuman.BaseAgility; //No weapon related to the Weapon mastery so no bonus

            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilHuman));

            Weapon wmWeapon = new Weapon("perfect weapon", belterius.WeaponMastery);
            belterius.WeaponHolder.Add(wmWeapon);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + Capacity.PhychicPowerStrenght + Capacity.WeaponMasteryStrenght) - evilHuman.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilHuman));

            //Multiples Items, Weapon Mastery, and psychic immune
            //WARNING TEST WILL FAIL IF ORC IS NOT IMMUN TO PSYCHIC ANYMORE, can check in Ennemy isWeakToPsychic
            SpecialItem ring = new SpecialItemCombat("magic ring", 6, 0);
            belterius.AddLoot(ring);
            Enemy evilOrc = new Enemy("Common Orc", 15, 10, EnemyTypes.Orc);
            expectedStrenghtDifference = (heroBaseAgility + ((SpecialItemCombat)shield).AgilityBonus + ((SpecialItemCombat)ring).AgilityBonus + Capacity.WeaponMasteryStrenght) - evilOrc.BaseAgility;

            Assert.AreEqual(expectedStrenghtDifference, belterius.FindStrenghtDifference(evilOrc));

        }

        [TestMethod]
        public void HeroFight()
        {
            Hero hero = new Hero("hero");
            Enemy beast = new Enemy("beast", 22, 20, EnemyTypes.Beast);
            try
            {
                bool battleOver = false;
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
            Consumable consummable = CreateLoot.CreateConsumable.MinorHealthPotion();
            Consumable consummable2 = new Consumable("Random Consumable", 12, 1);
            Consumable consummable4 = new Consumable("Random Consumable", 12, 1);//Allow to check if the override Equal works on Contains()
            Consumable consummable3 = new Consumable("Random Consumable FALSE", 12, 1);
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
