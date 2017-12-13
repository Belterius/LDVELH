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
            Enemy evilHuman = new Enemy("Tagazoc", 13, 10, EnemyTypes.Human);
            Enemy evilOrc = new Enemy("GroDur", 10, 20, EnemyTypes.Orc);
            Enemy beast = new Enemy("BigBear", 16, 20, EnemyTypes.Beast);

            Assert.AreEqual(Enemy.EnemiesWeakToPhychic.Contains(evilHuman.ClassType), evilHuman.IsWeakToPhychic());
            Assert.AreEqual(Enemy.EnemiesWeakToPhychic.Contains(beast.ClassType), beast.IsWeakToPhychic());
            Assert.AreEqual(Enemy.EnemiesWeakToPhychic.Contains(evilOrc.ClassType), evilOrc.IsWeakToPhychic());
        }
    }
}
