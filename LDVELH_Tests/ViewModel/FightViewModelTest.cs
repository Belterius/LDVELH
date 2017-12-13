using System;
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
            Hero hero = new Hero("NoName");
            Enemy enemy = new Enemy("AnEnemy", 10, 15, EnemyTypes.Human);
            _viewModel = new FightViewModel(hero, enemy);
        }

        private readonly FightViewModel _viewModel;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
            Hero hero = new Hero("NoName");
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("Hero", e.PropertyName);
                Assert.AreEqual(hero, _viewModel.Hero);
            };
            _viewModel.Hero = hero;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EnemyTest()
        {
            Enemy enemy = new Enemy("AnEnemy", 10, 15, EnemyTypes.Human);
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("Enemy", e.PropertyName);
                Assert.AreEqual(enemy, _viewModel.Enemy);
            };
            _viewModel.Enemy = enemy;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void HeroDamageTakenTest()
        {
            bool didFire = false;
            int Damage = 5;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("HeroDamageTaken", e.PropertyName);
            };
            _viewModel.HeroDamageTaken = Damage;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EscapeTextTest()
        {
            bool didFire = false;
            string EscapeText = "Escaped!";
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("EscapeText", e.PropertyName);
                Assert.AreEqual(EscapeText, _viewModel.EscapeText);
            };
            _viewModel.EscapeText = EscapeText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void EnemyDamageTaken()
        {
            bool didFire = false;
            int Damage = 5;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("EnemyDamageTaken", e.PropertyName);
            };
            _viewModel.EnemyDamageTaken = Damage;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void NextRoundTextTest()
        {
            bool didFire = false;
            string NextRoundText = "Next Round";
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("NextRoundText", e.PropertyName);
                Assert.AreEqual(NextRoundText, _viewModel.NextRoundText);
            };
            _viewModel.NextRoundText = NextRoundText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RoundNumberTest()
        {
            bool didFire = false;
            int RoundNumber = 5;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RoundNumber", e.PropertyName);
                Assert.AreEqual(RoundNumber, _viewModel.RoundNumber);
            };
            _viewModel.RoundNumber = RoundNumber;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RunRoundNumberTest()
        {
            bool didFire = false;
            int RunRoundNumber = 5;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RunRoundNumber", e.PropertyName);
                Assert.AreEqual(RunRoundNumber, _viewModel.RunRoundNumber);
            };
            _viewModel.RunRoundNumber = RunRoundNumber;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RoundNumberTextTest()
        {
            bool didFire = false;
            string RoundNumberText = "You can run";
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RoundNumberText", e.PropertyName);
                Assert.AreEqual(RoundNumberText, _viewModel.RoundNumberText);
            };
            _viewModel.RoundNumberText = RoundNumberText;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void CanRunTest()
        {
            bool didFire = false;
            System.Windows.Visibility CanRun = System.Windows.Visibility.Visible;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("CanRun", e.PropertyName);
                Assert.AreEqual(CanRun, _viewModel.CanRun);
            };
            _viewModel.CanRun = CanRun;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RanAwayTest()
        {
            bool didFire = false;
            bool RanAway = true;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RanAway", e.PropertyName);
                Assert.AreEqual(RanAway, _viewModel.RanAway);
            };
            _viewModel.RanAway = RanAway;
            Assert.IsTrue(didFire);
        }
        [TestMethod]
        public void RunCommandTest()
        {
            bool didFire = false;
            bool didEnded = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("RanAway", e.PropertyName);
                Assert.AreEqual(true, _viewModel.RanAway);
            };
            _viewModel.FightEndedChanged += (object sender, EventArgs e) =>
            {
                didEnded = true;
            };
            _viewModel.RunCommand.Execute(null);
            Assert.IsTrue(didFire);
            Assert.IsTrue(didEnded);
        }
    }
}
