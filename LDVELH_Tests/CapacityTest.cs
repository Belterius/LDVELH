using System;
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
            Capacity hidingCapacity;
            Capacity phychicCapacity;

            hidingCapacity = new Capacity(CapacityType.Hiding);
            phychicCapacity = new Capacity(CapacityType.PsychicPower);

            Assert.AreEqual(true, hidingCapacity.getCapacityType == CapacityType.Hiding);
            Assert.AreEqual(true, phychicCapacity.getCapacityType == CapacityType.PsychicPower);
            Assert.AreEqual(false, hidingCapacity.getCapacityType == CapacityType.PsychicPower);
        }

        
    }
}
