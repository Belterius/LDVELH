using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class WeaponHolderTests
    {
        [TestMethod]
        public void WeaponHolder_AddOnEmpty_Tests()
        {
            Weapon basicSword1 = new Weapon("basic sword", WeaponTypes.Sword);
            //Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);
            
            WeaponHolder basicWeaponHolder = new WeaponHolder();

            basicWeaponHolder.Add(basicSword1);

            Assert.AreEqual(true, basicWeaponHolder.getWeapons.Contains(basicSword1));

        }

        [TestMethod]
        public void WeaponHolder_AddOnNonEmpty_Tests()
        {
            Weapon basicSword1 = new Weapon("basic sword", WeaponTypes.Sword);
            Weapon advancedSword = new Weapon("advanced sword", WeaponTypes.Sword);
            //Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);

            WeaponHolder basicWeaponHolder = new WeaponHolder();

            basicWeaponHolder.Add(basicSword1);
            basicWeaponHolder.Add(advancedSword);

            Assert.AreEqual(true, basicWeaponHolder.getWeapons.Contains(basicSword1));
            Assert.AreEqual(true, basicWeaponHolder.getWeapons.Contains(advancedSword));

        }

        [TestMethod]
        public void WeaponHolder_AddOnFull_Tests()
        {
            Weapon basicSword1 = new Weapon("basic sword", WeaponTypes.Sword);
            Weapon advancedSword = new Weapon("advanced sword", WeaponTypes.Sword);
            Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);

            WeaponHolder basicWeaponHolder = new WeaponHolder();

            basicWeaponHolder.Add(basicSword1);
            basicWeaponHolder.Add(advancedSword);

            try
            {
                basicWeaponHolder.Add(basicSpear);
                Assert.Fail();//we should have thrown an exception and gone in the catch
            }
            catch (WeaponHolderFullException)
            {
                Assert.AreEqual(true, basicWeaponHolder.getWeapons.Contains(basicSword1));
                Assert.AreEqual(true, basicWeaponHolder.getWeapons.Contains(advancedSword));
            }

        }

        [TestMethod]
        public void WeaponHolder_ContainsWeaponType_Tests()
        {

            Weapon advancedSword = new Weapon("advanced sword", WeaponTypes.Sword);
            Weapon basicSpear = new Weapon("basic spear", WeaponTypes.Spear);
            WeaponHolder basicWeaponHolder = new WeaponHolder();
            basicWeaponHolder.Add(basicSpear);
            basicWeaponHolder.Add(advancedSword);

            Assert.AreEqual(true, basicWeaponHolder.Contains(WeaponTypes.Sword));
            Assert.AreEqual(true, basicWeaponHolder.Contains(WeaponTypes.Spear));
            Assert.AreEqual(false, basicWeaponHolder.Contains(WeaponTypes.Hammer));

        }
    }
}
