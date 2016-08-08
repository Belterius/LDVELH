using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class EnemyTests
    {
        [TestMethod]
        public void EnnemyWeakToPsychic()
        {
            Enemy evilHuman = new Enemy("Tagazoc", 13, 10, EnnemyTypes.Human);
            Enemy evilOrc = new Enemy("GroDur", 10, 20, EnnemyTypes.Orc);
            Enemy Beast = new Enemy("BigBear", 16, 20, EnnemyTypes.Beast);

            Assert.AreEqual(Enemy.enemiesWeakToPhychic.Contains(evilHuman.ClassType), evilHuman.isWeakToPhychic());
            Assert.AreEqual(Enemy.enemiesWeakToPhychic.Contains(Beast.ClassType), Beast.isWeakToPhychic());
            Assert.AreEqual(Enemy.enemiesWeakToPhychic.Contains(evilOrc.ClassType), evilOrc.isWeakToPhychic());
        }
    }
}
