using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class RollsTests
    {
        [TestMethod]
        public void RollD6()
        {
            const int minRoll = 1;
            const int maxRoll = 6;
            int actualRoll = DiceRoll.D6Roll();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }

        [TestMethod]
        public void RollD10()
        {
            const int minRoll = 1;
            const int maxRoll = 10;
            int actualRoll = DiceRoll.D10Roll();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }

        [TestMethod]
        public void RollD10_0()
        {
            const int minRoll = 0;
            const int maxRoll = 9;
            int actualRoll = DiceRoll.D10Roll0();

            Assert.IsTrue(minRoll <= actualRoll, "The actualCount was not greater than " + minRoll);
            Assert.IsTrue(actualRoll <= maxRoll, "The actualCount was not lower than " + maxRoll);
        }
    }
}
