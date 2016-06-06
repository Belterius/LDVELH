using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WindowsForm;

namespace LDVELH_Tests
{
    [TestClass]
    public class CapacityTest
    {
        [TestMethod]
        public void TypeCapacity()
        {
            Capacity hidingCapacity;
            Capacity phychicCapacity;

            hidingCapacity = new Capacity(CapacityType.Hiding);
            phychicCapacity = new Capacity(CapacityType.PsychicPower);

            Assert.AreEqual(true, hidingCapacity.GetCapacityType() == CapacityType.Hiding);
            Assert.AreEqual(true, phychicCapacity.GetCapacityType() == CapacityType.PsychicPower);
            Assert.AreEqual(false, hidingCapacity.GetCapacityType() == CapacityType.PsychicPower);
        }

        public void HeroPossesCapacity()
        {
            Hero Belterius = new Hero("Belterius");
            Capacity hidingCapacity = new Capacity(CapacityType.Hiding);
            
        }
    }
}
