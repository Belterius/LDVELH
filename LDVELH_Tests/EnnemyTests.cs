using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class EnnemyTests
    {
        [TestMethod]
        public void EnnemyWeakToPsychic()
        {
            Ennemy evilHuman = new Ennemy("Tagazoc", 13, 10, EnnemyTypes.Human);
            Ennemy evilOrc = new Ennemy("GroDur", 10, 20, EnnemyTypes.Orc);
            Ennemy Beast = new Ennemy("BigBear", 16, 20, EnnemyTypes.Beast);

            Assert.AreEqual(true, evilHuman.isWeakToPhychic());
            Assert.AreEqual(true, Beast.isWeakToPhychic());
            Assert.AreEqual(false, evilOrc.isWeakToPhychic());
        }
    }
}
