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
            int myHealthPoint = myHero.getActualHitPoint();

            try
            {
                myHero.kill();
                Assert.Fail();
            }
            catch (YouAreDeadException)
            {
                Assert.AreEqual(0, myHero.getActualHitPoint());
            }

        }
        [TestMethod]
        public void CharacterTakeDamageTest()
        {
            Hero myHero = new Hero("TestHero");
            int myHealthPoint = myHero.getActualHitPoint();
            int damageTaken = DiceRoll.D10Roll();

            myHero.takeDamage(damageTaken);

            Assert.AreEqual(myHealthPoint - damageTaken, myHero.getActualHitPoint());
        }
    }
}
