using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class CapacityTest
    {
        [TestMethod]
        public void TypeCapacity()
        {
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);
            Capacity phychicCapacity = new Capacity(CapacityType.PsychicPower);

            Assert.AreEqual(true, hidingCapacity.CapacityKind == CapacityType.Hiding);
            Assert.AreEqual(true, phychicCapacity.CapacityKind == CapacityType.PsychicPower);
            Assert.AreEqual(false, hidingCapacity.CapacityKind == CapacityType.PsychicPower);
        }

       
    }
}
