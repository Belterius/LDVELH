using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;
using LDVELH_WPF.ViewModel;

namespace LDVELH_Tests
{
    /// <summary>
    /// Summary description for FightViewModelTest
    /// </summary>
    [TestClass]
    public class FightViewModelTest
    {
        public FightViewModelTest()
        {
            Hero Hero = new Hero("NoName");
            Enemy Enemy = new Enemy("AnEnemy", 10, 15, EnemyTypes.Human);
            ViewModel = new FightViewModel(Hero, Enemy);
        }

        private TestContext testContextInstance;

        private FightViewModel ViewModel;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void HeroTest()
        {
            Hero Hero = new Hero("NoName");
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("Hero", e.PropertyName);
                Assert.AreEqual(Hero, ViewModel.Hero);
            };
            ViewModel.Hero = Hero;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EnemyTest()
        {
            Enemy Enemy = new Enemy("AnEnemy", 10, 15, EnemyTypes.Human);
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("Enemy", e.PropertyName);
                Assert.AreEqual(Enemy, ViewModel.Enemy);
            };
            ViewModel.Enemy = Enemy;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void HeroDamageTakenTest()
        {
            bool didFire = false;
            int Damage = 5;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("HeroDamageTaken", e.PropertyName);
            };
            ViewModel.HeroDamageTaken = Damage;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EscapeTextTest()
        {
            bool didFire = false;
            string EscapeText = "Escaped!";
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("EscapeText", e.PropertyName);
                Assert.AreEqual(EscapeText, ViewModel.EscapeText);
            };
            ViewModel.EscapeText = EscapeText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EnemyDamageTaken()
        {
            bool didFire = false;
            int Damage = 5;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("EnemyDamageTaken", e.PropertyName);
            };
            ViewModel.EnemyDamageTaken = Damage;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void NextRoundTextTest()
        {
            bool didFire = false;
            string NextRoundText = "Next Round";
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("NextRoundText", e.PropertyName);
                Assert.AreEqual(NextRoundText, ViewModel.NextRoundText);
            };
            ViewModel.NextRoundText = NextRoundText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RoundNumberTest()
        {
            bool didFire = false;
            int RoundNumber = 5;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RoundNumber", e.PropertyName);
                Assert.AreEqual(RoundNumber, ViewModel.RoundNumber);
            };
            ViewModel.RoundNumber = RoundNumber;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RunRoundNumberTest()
        {
            bool didFire = false;
            int RunRoundNumber = 5;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RunRoundNumber", e.PropertyName);
                Assert.AreEqual(RunRoundNumber, ViewModel.RunRoundNumber);
            };
            ViewModel.RunRoundNumber = RunRoundNumber;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RoundNumberTextTest()
        {
            bool didFire = false;
            string RoundNumberText = "You can run";
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RoundNumberText", e.PropertyName);
                Assert.AreEqual(RoundNumberText, ViewModel.RoundNumberText);
            };
            ViewModel.RoundNumberText = RoundNumberText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void CanRunTest()
        {
            bool didFire = false;
            System.Windows.Visibility CanRun = System.Windows.Visibility.Visible;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("CanRun", e.PropertyName);
                Assert.AreEqual(CanRun, ViewModel.CanRun);
            };
            ViewModel.CanRun = CanRun;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RanAwayTest()
        {
            bool didFire = false;
            bool RanAway = true;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RanAway", e.PropertyName);
                Assert.AreEqual(RanAway, ViewModel.RanAway);
            };
            ViewModel.RanAway = RanAway;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RunCommandTest()
        {
            bool didFire = false;
            bool didEnded = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RanAway", e.PropertyName);
                Assert.AreEqual(true, ViewModel.RanAway);
            };
            ViewModel.FightEndedChanged += (object sender, EventArgs e) =>
            {
                didEnded = true;
            };
            ViewModel.RunCommand.Execute(null);
            Assert.IsTrue(didFire);
            Assert.IsTrue(didEnded);
        }
    }
}
