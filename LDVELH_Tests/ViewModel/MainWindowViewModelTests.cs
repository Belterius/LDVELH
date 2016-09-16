using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDVELH_WPF.ViewModel.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        public MainWindowViewModelTests()
        {
            Hero Hero = new Hero("NoName");
            ViewModel = new MainWindowViewModel(Hero, false);
        }

        private MainWindowViewModel ViewModel;

        [TestMethod()]
        public void ActionButtonHasChangedTest()
        {
            StoryParagraph Paragraph = new StoryParagraph("AParagraph", 100);
            bool didFire = false;
            bool didEnded = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual(Paragraph, ViewModel.MyStory.ActualParagraph);
            };
            ViewModel.ActionButtonChanged += () =>
            {
                didEnded = true;
            };
            ViewModel.MyStory.ActualParagraph = Paragraph;
            Assert.IsTrue(didFire);
            Assert.IsTrue(didEnded);
        }

        [TestMethod()]
        public void HeroTest()
        {
            Hero Hero = new Hero("NoName");
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual(Hero, ViewModel.Hero);
            };
            ViewModel.Hero = Hero;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void UseItemCommandTest()
        {
            Item SelectedItem = new Consummable("SelectedItem", 1, 2);
            bool didFire = false;
            bool didChangeCharges = false;

            ViewModel.Hero.AddLoot(SelectedItem);
            ViewModel.SelectedItem = SelectedItem;
            Assert.IsTrue(ViewModel.Hero.PossesItem(SelectedItem.Name));

            SelectedItem.PropertyChanged += (s, e) =>
            {
                didFire = true;
                if (e.PropertyName.Equals("ChargesLeft"))
                {
                    didChangeCharges = true;
                }
                Assert.AreEqual(SelectedItem, ViewModel.SelectedItem);
            };

            ViewModel.UseItemCommand.Execute(SelectedItem);
            Assert.IsTrue((ViewModel.Hero.PossesItem(SelectedItem.Name)));
            Assert.IsTrue(didFire);
            Assert.IsTrue(didChangeCharges);
        }

        [TestMethod()]
        public void ThrowLootCommandTest()
        {
            Item SelectedItem = new Consummable("SelectedItem", 1, 1);

            ViewModel.Hero.AddLoot(SelectedItem);
            Assert.IsTrue(ViewModel.Hero.PossesItem(SelectedItem.Name));


            ViewModel.ThrowLootCommand.Execute(SelectedItem);
            Assert.IsTrue(!(ViewModel.Hero.PossesItem(SelectedItem.Name)));
        }

        [TestMethod()]
        public void SelectedItemTest()
        {
            Item SelectedItem = new Consummable("SelectedItem", 1, 1);
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("SelectedItem", e.PropertyName);
                Assert.AreEqual(SelectedItem, ViewModel.SelectedItem);
            };
            ViewModel.SelectedItem = SelectedItem;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void SelectedWeaponTest()
        {
            Weapon SelectedWeapon = new Weapon("SelectedWeapon", WeaponTypes.Axe);
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("SelectedWeapon", e.PropertyName);
                Assert.AreEqual(SelectedWeapon, ViewModel.SelectedWeapon);
            };
            ViewModel.SelectedWeapon = SelectedWeapon;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void MyStoryTest()
        {
            Story MyStory = new Story("myTitle", ViewModel.Hero);
            bool didFire = false;
            ViewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("MyStory", e.PropertyName);
                Assert.AreEqual(MyStory, ViewModel.MyStory);
            };
            ViewModel.MyStory = MyStory;
            Assert.IsTrue(didFire);
        }
    }
}