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

            hidingCapacity = new Capacity(CapacityType.Camouflage);
            phychicCapacity = new Capacity(CapacityType.PuissancePsychique);

            Assert.AreEqual(true, hidingCapacity.getCapacityType == CapacityType.Camouflage);
            Assert.AreEqual(true, phychicCapacity.getCapacityType == CapacityType.PuissancePsychique);
            Assert.AreEqual(false, hidingCapacity.getCapacityType == CapacityType.PuissancePsychique);
        }

        
    }
}
