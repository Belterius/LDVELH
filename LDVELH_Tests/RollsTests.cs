using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;
using System.Diagnostics;

namespace LDVELH_Tests
{
    [TestClass]
    public class RollsTests
    {
        [TestMethod]
        public void RollD6()
        {
            int minRoll = 1;
            int maxRoll = 6;
            int actualRoll;

            actualRoll = DiceRoll.D6Roll();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }

        [TestMethod]
        public void RollD10()
        {
            int minRoll = 1;
            int maxRoll = 10;
            int actualRoll;

            actualRoll = DiceRoll.D10Roll();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }

        [TestMethod]
        public void RollD10_0()
        {
            int minRoll = 0;
            int maxRoll = 9;
            int actualRoll;

            actualRoll = DiceRoll.D10Roll0();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }
    }
}
