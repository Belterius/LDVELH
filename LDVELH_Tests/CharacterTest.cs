using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void CharacterKillTest()
        {
            Hero myHero = new Hero("TestHero");
            int myHealthPoint = myHero.ActualHitPoint;

            try
            {
                myHero.Kill();
                Assert.Fail();
            }
            catch (YouAreDeadException)
            {
                Assert.AreEqual(0, myHero.ActualHitPoint);
            }

        }
        [TestMethod]
        public void CharacterTakeDamageTest()
        {
            Hero myHero = new Hero("TestHero");
            int myHealthPoint = myHero.ActualHitPoint;
            int damageTaken = DiceRoll.D10Roll();

            myHero.TakeDamage(damageTaken);

            Assert.AreEqual(myHealthPoint - damageTaken, myHero.ActualHitPoint);
        }
    }
}
